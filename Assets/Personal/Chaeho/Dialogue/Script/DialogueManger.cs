using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine.Serialization;

public class Dialouge//다이얼로그 객체
{
    private string myDefault = "";
    public string name, content, eventParam;

    public int illustId,
        illustCategori,
        backgroundId,
        backgroundCategori,
        effectId,
        bgmId,
        soundId,
        eventId;
    public float effectParam;

    public Dialouge(
        string name = "", string content = "",
        string illustId = "", string illustCategori = "",
        string backgroundId = "", string backgroundCategori = "",
        string effectId="", string effectParam = "", 
        string soundId="", string bgmId="",
        string eventId="", string eventParam=""
        )
    {
        this.name =  name;
        this.content = content;
        this.illustId = illustId == myDefault ? -1 : int.Parse(illustId);
        this.illustCategori = illustCategori==myDefault ? -1 : int.Parse(illustCategori);
        this.backgroundId = backgroundId == myDefault ? -1 : int.Parse(backgroundId);
        this.backgroundCategori = backgroundCategori == myDefault ? -1 : int.Parse(backgroundCategori);
        this.effectId = effectId==myDefault ? -1 : int.Parse(effectId);
        this.effectParam = effectParam == myDefault ? -1 : float.Parse(effectParam);
        this.soundId = soundId == myDefault ? -1 : int.Parse(soundId);
        this.bgmId = bgmId == myDefault ? -1 : int.Parse(bgmId);
        this.eventId = eventId == myDefault ? -1 : int.Parse(eventId);
        this.eventParam = eventParam;
        }
}

public class DialogueManger : MonoBehaviour
{
    [SerializeField] private GameObject[] diaolgueObject;
    [SerializeField] private IllustHandler standIllust;//스탠딩 일러 매니저
    [SerializeField] private IllustHandler backgroundIllust;//스탠딩 일러 매니저
    [SerializeField] private EffectManager effectManager;//효과 매니저
    [SerializeField] private ChoiceManager choiceManager;

    [SerializeField] public TMP_Text nameText;
    [SerializeField] public TMP_Text contentText;

    public bool isSkipAnim = false; //오픈, 클로즈 애니메이션 여부
    public bool isChoosing;
    public bool isExecuting = false;
    public int index;//다이얼로그 인덱스값
    private Dialouge[] dialougeArr;//다이이얼로그 배열
    private Coroutine typingCo;

    private string currentAdress;

    [SerializeField] private string testAdress;
    
    private void Start()
    {
        //Week1/loc1/dlg0.csv
        StartDialogue(testAdress);    
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isExecuting && !isChoosing)
        {
            ProceedDialogue();
        }
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            StartDialogue(dialogueAdress: "/Src/Dialogue/CSV/Prologue.csv", startIndex: 0);
        }*/
    }
    
    
    
    void ShowDialogue(Dialouge dialogue)//현재 위치의 대화를 화면에 표시
    {
        bool isExistBg = false;
        nameText.text = dialogue.name;//이름 텍스트 변경
    
        if (typingCo != null) 
        { 
            StopCoroutine(typingCo); // 만약 타이핑 효과가 재생 중이라면 중지
        }

        if (dialogue.content != "-1") 
        { 
            typingCo = StartCoroutine(TypingEffect(dialogue.content)); // 대화 내용이 있는 경우 타이핑 효과 시작
        }

        if (dialogue.illustId != -1 && dialogue.illustCategori != -1)//일러스트 정보가 있는 경우
        { 
            standIllust.illusts[dialogue.illustId, dialogue.illustCategori].SetActive(true); // 일러스트 활성화
        }

        if (dialogue.backgroundId != -1 && dialogue.backgroundCategori != -1) //배경 정보가 있는 경우
        {
            isExistBg = true;
            backgroundIllust.illusts[dialogue.backgroundId, dialogue.backgroundCategori].gameObject.SetActive(true); // 배경 활성화
        }

        if (dialogue.effectId != -1) //이펙트 정보가 있는 경우
        {
            GameObject paramGameObject = null;

            if (isExistBg && dialogue.effectId == 3)
            {
                paramGameObject = backgroundIllust.illusts[dialogue.backgroundId, dialogue.backgroundCategori];
                effectManager.StartEffect(dialogue.effectId, param: dialogue.effectParam, getGameObject: paramGameObject); // 배경이 있는 경우에만 특정 이펙트 시작
            }
            else
            {
                effectManager.StartEffect(dialogue.effectId, param: dialogue.effectParam); // 배경이 없거나 특정 이펙트가 아닌 경우 이펙트 시작
            }
        }

        if (dialogue.bgmId != -1) //배경 음악 정보가 있는 경우
        {
            if (dialogue.bgmId == 0)
            {
                //게임매니저(or 사운드매니저).배경음악 종료
                //ex) gameManager.StopBGM();
            }
            else
            {
                //게임매니저(or 사운드매니저).배경음악 재생
                //ex) gameManager.PlayBGM(int형 배경음악 정보);
            }
        }
        
        if (dialogue.soundId != -1) //효과음 음악 정보가 있는 경우
        {
            //게임매니저(or 사운드매니저).효과음악 재생
            //ex) gameManager.PlaySound(int형 효과음 정보);
        }
        

        if (dialogue.eventId != -1)//이벤트 정보가 있는 경우
        {
            switch (dialogue.eventId){
                case 0:
                    break;
                case 1://선택지 선택하기
                    if (dialogue.eventParam != "")
                    {
                        print($"{dialogue.eventId} {dialogue.eventParam}" );
                        choiceManager.StartChoice(dialogue.eventParam);
                        isChoosing = true;
                    }
                    break;
                case 2://엔딩
                    //게임 엔딩
                default:
                    break;
            }
        }
    }

    void GenerateDialogue(string dialogueAdress = "")
    {
        List<Dictionary<string, object>> csvData;
        csvData = CSVReader.Read(dialogueAdress);
        dialougeArr = new Dialouge[csvData.Count];
        
        for (int i = 0; i < csvData.Count; i++)
        {
            string name = "",
                content = "",
                illustId = "",
                illustCategori = "",
                backgroundId = "",
                backgroundCategori = "",
                effectId = "",
                effectParam = "",
                soundId = "",
                bgmId = "",
                eventId = "",
                eventParam = "";
                
            name = csvData[i]["name"].ToString();
            content = csvData[i]["content"].ToString();
            illustId = csvData[i]["illustId"].ToString();
            illustCategori = csvData[i]["illustCategori"].ToString();
            backgroundId = csvData[i]["backgroundId"].ToString();
            backgroundCategori = csvData[i]["backgroundCategori"].ToString();
            effectId = csvData[i]["effectId"].ToString();
            effectParam = csvData[i]["effectParam"].ToString();
            soundId = csvData[i]["soundId"].ToString();
            bgmId = csvData[i]["bgmId"].ToString();
            eventId = csvData[i]["eventId"].ToString();
            eventParam = csvData[i]["eventParam"].ToString();

            Dialouge generateDlg = new Dialouge(name: name, content: content,
                illustId: illustId, illustCategori: illustCategori,
                backgroundId: backgroundId, backgroundCategori: backgroundCategori,
                effectId: effectId, effectParam: effectParam,
                soundId: soundId, bgmId: bgmId,
                eventId: eventId, eventParam: eventParam
            );
            dialougeArr[i] = generateDlg;
        }
    }
    
    public void StartDialogue(string dialogueAdress="", int startIndex=0, bool isKeeping = false)
    {
        if(!isExecuting || isKeeping)
        {
            if (dialogueAdress != "")
            {
                print("다이얼로그 실행");
                currentAdress = dialogueAdress.Split("/")[^1].Split(".")[0];
                isExecuting = true;
                GenerateDialogue(dialogueAdress);
                //다이얼로그 파싱
                index = startIndex;
                effectManager.InitEffect();
                choiceManager.InitChoice();
                for(int i = 0; diaolgueObject.Length > i && !isKeeping; i++)//다이얼로그 오브젝트 활성화
                {
                    diaolgueObject[i].SetActive(true);
                }

                StartCoroutine(OpenDialogueBox());
            }
            else
            {
                Debug.LogError("DialogueManager: no dialogue adress in StartDialouge()");
            }
        }
        else
        {
            print("다이얼로그 중복 실행 불가");
            return;
        }
        
    }

    public void CloseDialogue()
    {
        for (int i = 0; diaolgueObject.Length > i; i++)
        {
            diaolgueObject[i].SetActive(false);
        }
        Debug.Log($"다이얼로그 종료");
        isExecuting = false;
    }
    
    public void ProceedDialogue(bool isKeeping = false)
    {
        if (effectManager.effectCo != null)//이펙트가 실행중이라면
        {
            if(index < dialougeArr.Length-1)
            {
                effectManager.StopEffect();
                effectManager.InitEffect();
            }
        }
        else//보통의 경우
        {
            effectManager.InitEffect();
            if (index >= 0)//이전의 다이얼로그의 일러스트를 비활성화함
            {
                if (dialougeArr[index].illustId != -1 && dialougeArr[index].illustCategori != -1)
                {
                    standIllust.illusts[dialougeArr[index].illustId, dialougeArr[index].illustCategori]
                        .SetActive(false);
                }

                if (dialougeArr[index].backgroundId != -1 && dialougeArr[index].backgroundCategori != -1)
                {
                    backgroundIllust.illusts[dialougeArr[index].backgroundId, dialougeArr[index].backgroundCategori]
                        .SetActive(false);
                }
            }
            
            if(index<dialougeArr.Length-1)//실행
            {
                index++;
                ShowDialogue(dialougeArr[index]);
            }
            else//종료
            {
                if(!isKeeping) StartCoroutine(CloseDialogueBox());
            }
        }
    }
    
    IEnumerator TypingEffect(string content)
    {
        for (int i = 0; i < content.Length+1; i++)
        {
            yield return new WaitForSeconds(0.03f);
            contentText.text = content.Substring(0,i);
        }
    }

    IEnumerator OpenDialogueBox()
    {

        if(!isSkipAnim)
        {
            RectTransform rectTransform = diaolgueObject[2].GetComponent<RectTransform>();

            Vector3 originScale = new Vector3(1, 1, 1);
            float nowScaleY = 0;
            rectTransform.localScale =
                new Vector3(originScale.x, 0, originScale.z);

            while (nowScaleY < originScale.y)
            {
                rectTransform.localScale =
                    new Vector3(originScale.x, nowScaleY, originScale.z);

                nowScaleY += 10 * Time.deltaTime;
                yield return null;
            }

            rectTransform.localScale =
                new Vector3(originScale.x, originScale.y, originScale.z);
        }
        
        ShowDialogue(dialougeArr[index]);
    }
    
    IEnumerator CloseDialogueBox()
    {
        if(!isSkipAnim)
        {
            RectTransform rectTransform = diaolgueObject[2].GetComponent<RectTransform>();

            Vector3 originScale = new Vector3(1, 1, 1);

            float nowScaleY = originScale.y;

            while (0 < nowScaleY)
            {
                rectTransform.localScale =
                    new Vector3(originScale.x, nowScaleY, originScale.z);

                nowScaleY -= 10 * Time.deltaTime;
                yield return null;
            }

            rectTransform.localScale =
                new Vector3(originScale.x, 0, originScale.z);
        }
        
        CloseDialogue();
    }
    
}

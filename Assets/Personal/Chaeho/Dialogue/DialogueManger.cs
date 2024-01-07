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
    public string name, content;
    public int illustId,
        illustCategori,
        backgroundId,
        backgroundCategori,
        effectId,
        soundId,
        eventId;       
    public float effectParam;

    public Dialouge(
        string name = "", string content = "",
        string illustId = "", string illustCategori = "",
        string backgroundId = "", string backgroundCategori = "",
        string effectId="", string effectParam = "", 
        string soundId="", string eventId=""
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
        this.eventId = eventId == myDefault ? -1 : int.Parse(eventId);
        }
}

public class DialogueManger : MonoBehaviour
{
    [SerializeField] private GameObject[] diaolgueObject;
    [SerializeField] private IllustHandler standIllust;//스탠딩 일러 매니저
    [SerializeField] private IllustHandler backgroundIllust;//스탠딩 일러 매니저
    [SerializeField] private EffectManager effectManager;//효과 매니저

    [SerializeField] public TMP_Text nameText;
    [SerializeField] public TMP_Text contentText;
    
    public bool isExecuting = false;
    public int index;//다이얼로그 인덱스값
    private Dialouge[] dialougeArr;//다이이얼로그 배열
    private Coroutine typingCo;

    private string currentAdress;

    private void Start()
    {
        StartDialogue("/Personal/Chaeho/asset/Dialogue/CSV/Prologue copy.csv");    
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isExecuting)
        {
            ProceedDialogue();
        }
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            StartDialogue(dialogueAdress: "/Src/Dialogue/CSV/Prologue.csv", startIndex: 0);
        }*/
    }

    
    void ShowDialogue(Dialouge dialouge)//현재 위치의 다이얼로그를 화면에 나타냄
    {
        bool isExistBg = false;
        nameText.text = dialouge.name;//이름 텍스트 변경
        if (typingCo != null) { StopCoroutine(typingCo); }//만약 타이핑효과가 재생중이라면
        if(dialouge.content != "-1") { typingCo = StartCoroutine(TypingEffect(dialouge.content)); }
        
        
        
        if (dialouge.illustId != -1 && dialouge.illustCategori != -1)//일러스트 정보가 있을 때만 실행
        { standIllust.illusts[dialouge.illustId, dialouge.illustCategori].SetActive(true); }

        if (dialouge.backgroundId != -1 && dialouge.backgroundCategori != -1) //배경 정보가 있으 때만 실행
        {
            backgroundIllust.illusts[dialouge.backgroundId, dialouge.backgroundCategori].gameObject.SetActive(true);
            isExistBg = true;
        }
        
        if (dialouge.effectId != -1) //이펙트 정보가 있을 때만 실행
        {
            GameObject paramGameObject = default;
            if (isExistBg && dialouge.effectId==3)
            {
                print('줌');
                paramGameObject = backgroundIllust.illusts[dialouge.backgroundId, dialouge.backgroundCategori];
                effectManager.StartEffect(dialouge.effectId, param:dialouge.effectParam, getGameObject:paramGameObject);
            }
            else
            {
                print("노줌");
                effectManager.StartEffect(dialouge.effectId, param: dialouge.effectParam);
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
            string name="",
                content="",
                illustId="",
                illustCategori="",
                backgroundId="",
                backgroundCategori="",
                effectId="",
                effectParam="",
                soundId="",
                eventId="";
                
            name = csvData[i]["name"].ToString();
            content = csvData[i]["content"].ToString();
            illustId = csvData[i]["illustId"].ToString();
            illustCategori = csvData[i]["illustCategori"].ToString();
            backgroundId = csvData[i]["backgroundId"].ToString();
            backgroundCategori = csvData[i]["backgroundCategori"].ToString();
            effectId = csvData[i]["effectId"].ToString();
            effectParam = csvData[i]["effectParam"].ToString();
            soundId = csvData[i]["soundId"].ToString();
            eventId = csvData[i]["eventId"].ToString();
                

            Dialouge generateDlg = new Dialouge(name: name, content: content,
                illustId: illustId, illustCategori: illustCategori,
                backgroundId: backgroundId, backgroundCategori: backgroundCategori,
                effectId: effectId, effectParam: effectParam,
                soundId: soundId,
                eventId: eventId
            );
            dialougeArr[i] = generateDlg;
        }
    }
    
    public void StartDialogue(string dialogueAdress="", int startIndex=0)
    {
        
        if(!isExecuting)
        {
            if (dialogueAdress != "")
            {
                print("다이얼로그 실행");
                currentAdress = dialogueAdress.Split("/")[^1].Split(".")[0];
                isExecuting = true;
                for (int i = 0; diaolgueObject.Length > i; i++)//다이얼로그 오브젝트 활성화
                {
                    diaolgueObject[i].SetActive(true);
                }
                GenerateDialogue(dialogueAdress);
                //다이얼로그 파싱
                index = startIndex;
                effectManager.InitEffect();
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

    void CloseDialogue()
    {
        Debug.Log($"다이얼로그 종료");
        isExecuting = false;
        for (int i = 0; diaolgueObject.Length > i; i++)
        {
            diaolgueObject[i].SetActive(false);
        }
        
        
    }

    void ProceedDialogue()
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
            if(index<dialougeArr.Length-1)//실행
            {
                index++;
                
                ShowDialogue(dialougeArr[index]);
            }
            else//종료
            {
                StartCoroutine(CloseDialogueBox());
            }

            if (index > 0)//이전의 다이얼로그의 일러스트를 비활성화함
            {
                try
                {
                    standIllust.illusts[dialougeArr[index - 1].illustId, dialougeArr[index - 1].illustCategori]
                        .SetActive(false);
                }
                catch { }
                try
                {
                    backgroundIllust.illusts[dialougeArr[index - 1].backgroundId, dialougeArr[index - 1].backgroundCategori]
                        .SetActive(false);
                }
                catch { }
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
        RectTransform rectTransform = diaolgueObject[2].GetComponent<RectTransform>();

        Vector3 originScale = new Vector3(1,1,1);
        float nowScaleY = 0;
        rectTransform.localScale =
            new Vector3(originScale.x , 0, originScale.z);                                                      
                
        while (nowScaleY < originScale.y)
        {
            rectTransform.localScale =
                new Vector3(originScale.x, nowScaleY, originScale.z);

            nowScaleY += 10 * Time.deltaTime;
            yield return null;
        }
        
        rectTransform.localScale =
            new Vector3(originScale.x, originScale.y, originScale.z);
        
        ShowDialogue(dialougeArr[index]);
    }
    
    IEnumerator CloseDialogueBox()
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
        
        CloseDialogue();
    }
    
    
}

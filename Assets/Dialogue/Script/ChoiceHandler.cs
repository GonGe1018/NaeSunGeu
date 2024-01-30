using UnityEngine;



public class ChoiceHandler : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] private DialogueManger dialogueManger;

    //주의!! Exute 함수는 게임 특성상 다양한 분기점이 존재함이 이유로서, 매우 더럽습니다. 꼼꼼히 보고 수정하시기 바랍니다.
    //극한의 하드코딩 결과물입니다.


    public void Excute(string cmd)
    {
        print(cmd);
        string[] splitCmd = cmd.Split('_');
        int weekNum = int.Parse(splitCmd[0].Substring(1)),
            locNum = int.Parse(splitCmd[1]), fileNum = int.Parse(splitCmd[2]),
            choiceNum = int.Parse(splitCmd[3]);
        if (weekNum == 0)
        {
            if (fileNum == 0)
            {
                if (choiceNum == 1)
                {
                    //왑짱이 눈치 주는데 계속 제로짱과 대화
                    //왑짱 호감도 다운, 제로짱 호감도 업
                    dialogueManger.ProceedDialogue(isKeeping: true);
                    dialogueManger.StartDialogue("DialogueCSV/Prologue/dlg0-1.csv", isKeeping: true);

                    //호감도
                    gameManager.SetLove("ZR", 5);
                    gameManager.SetLove("IW", -5);
                }
                else if (choiceNum == 2)
                {
                    //왑짱 호감도 업
                    //왑짱이 눈치 줘서 제로짱과 대화 중단
                    dialogueManger.ProceedDialogue(isKeeping: true);
                    dialogueManger.StartDialogue("DialogueCSV/Prologue/dlg0-2.csv", isKeeping: true);
                    gameManager.SetLove("IW", 5);
                }
            }

        }
        else if (weekNum == 1)
        {
            if (locNum == 1)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        //복잡한 상황에서 왑짱의 도움을 받는
                        //왑짱 호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc1/dlg0-1.csv", isKeeping: true);

                        gameManager.SetLove("IW", 5);

                    }
                    else if (choiceNum == 2)
                    {
                        //복잡한 상황에서 왑짱의 도움을 거절
                        //왑짱 호감도 다운
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc1/dlg0-2.csv", isKeeping: true);

                        gameManager.SetLove("IW", -5);
                    }
                }
            }
            else if (locNum == 4)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        //애드짱이 주는 맛스타를 먹음
                        //애드짱 호감도 많이 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc4/dlg0-1.csv", isKeeping: true);

                        gameManager.SetLove("ED", 7);
                    }
                    else if (choiceNum == 2)
                    {
                        //애드짱이 사주는 매점을 거부함
                        //애드짱 호감도 조금 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc4/dlg0-2.csv", isKeeping: true);

                        gameManager.SetLove("ED", 2);
                    }
                }
            }
            else if (locNum == 6)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        //알지짱 노래 엿듣다가 도망
                        //알지짱 호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0-1.csv", isKeeping: true);

                        gameManager.SetLove("RG", 5);
                    }
                    else if (choiceNum == 2)
                    {
                        //알지짱 노래 엿듣다가 바로 붙잡힘
                        //호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0-2.csv", isKeeping: true);

                        gameManager.SetLove("RG", 5);
                    }
                }
                else if (fileNum == 1)
                {
                    //알지짱 노래 엿듣다가 들켜서 도망가다가 잡힘
                    //호감도 업
                    dialogueManger.ProceedDialogue(isKeeping: true);
                    dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0-2.csv", isKeeping: true);

                    gameManager.SetLove("RG", 5);
                }
            }

        }
        else if (weekNum == 2)
        {
            if (locNum == 1)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        //레오를 쓰담는 경우
                        //애드짱 호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc1/dlg0-1.csv", isKeeping: true);

                        gameManager.SetLove("ED", 5);
                    }
                    else if (choiceNum == 2)
                    {
                        //애드짱을 쓰담는 경우
                        //철컹철컹 엔딩(대사파일 eventId 2로 수정 후 엔딩 정보 입력)
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc1/dlg0-2.csv", isKeeping: true);

                        //gameManager.setLove("ED", 5);
                    }
                }

            }
            else if (locNum == 2)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1 || choiceNum == 2)
                    {
                        //알지짱에게 틀딱 애니를 물어본 경우
                        //호감도 다운
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc2/dlg0-1.csv", isKeeping: true);

                        gameManager.SetLove("RG", -5);
                    }
                    else if (choiceNum == 3)
                    {
                        //알지짱에게 최신 애니를 물어본 경우
                        //호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc2/dlg0-2.csv", isKeeping: true);

                        gameManager.SetLove("RG", 5);
                    }
                }
                else if (fileNum == 1)
                {
                    if (choiceNum == 1)
                    {
                        //알지짱 탈룰라 만들기
                        //호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc2/dlg1-1.csv", isKeeping: true);

                        gameManager.SetLove("RG", 5);
                    }
                    else if (choiceNum == 2)
                    {
                        //자기 자신을 틀딱으로 만들기
                        //호감도 변동 x
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc2/dlg1-2.csv", isKeeping: true);
                    }
                }
            }
            else if(locNum == 3)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        //넘어지는 왑짱을 빨리 붙잡아서 국물이 나한테 다 튐
                        //호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc3/dlg0-1.csv", isKeeping: true);
                        
                        gameManager.SetLove("IW", 5);
                    }
                    else if (choiceNum == 2)
                    {
                        //넘어지는 왑짱을 붙잡음
                        //호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc3/dlg0-2.csv", isKeeping: true);
                        
                        gameManager.SetLove("IW", 5);
                    }
                    else if(choiceNum == 3)
                    {
                        //넘어지는 왑짱을 붙잡지 않음
                        //엔딩
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc3/dlg0-3.csv", isKeeping: true);
                    }
                }
            }
            else if (locNum == 4)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        //눈치 챙기고 제로짱의 기타수업을 얌전히 들음
                        //호감도 업
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc4/dlg0-1.csv", isKeeping: true);
                        
                        gameManager.SetLove("ZR", 5);
                    }
                    else if (choiceNum == 2)
                    {
                        //눈치 없게 실력을 뽐내다가 제로짱의 기타 줄을 끊어먹음
                        //호감도 대폭 다운
                        dialogueManger.ProceedDialogue(isKeeping: true);
                        dialogueManger.StartDialogue("DialogueCSV/Week2/loc4/dlg0-2.csv", isKeeping: true);
                        
                        gameManager.SetLove("ZR", -10);
                    }
                    
                }
            }
        }
        else if (weekNum == 3)
        {
            if (locNum == 1)
            {
                
            }
            else if (locNum == 3)
            {

                if (choiceNum == 1)
                {
                    //알지짱의 배드민턴 대결 수락
                    //호감도 업 * 2
                    dialogueManger.ProceedDialogue(isKeeping: true);
                    dialogueManger.StartDialogue("DialogueCSV/Week3/loc3/dlg0-1.csv", isKeeping: true);
                
                    gameManager.SetLove("RG", 10);
                }
                else if (choiceNum == 2)
                {
                    //알지짱의 배드민턴 대결 수락
                    //호감도 다운
                    dialogueManger.ProceedDialogue(isKeeping: true);
                    dialogueManger.StartDialogue("DialogueCSV/Week3/loc3/dlg0-2.csv", isKeeping: true);
                
                    gameManager.SetLove("RG", -5);
                }
            }
        }
        

    }

}

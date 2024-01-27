using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
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

        if (weekNum == 1)
        {
            if (locNum == 1)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        dialogueManger.ProceedDialogue(isKeeping:true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc1/dlg0-1.csv",isKeeping:true);
                    }
                    else if (choiceNum == 2)
                    {
                        dialogueManger.ProceedDialogue(isKeeping:true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc1/dlg0-2.csv",isKeeping:true);
                    }
                }
            }
            else if (locNum == 6)
            {
                if (fileNum == 0)
                {
                    if (choiceNum == 1)
                    {
                        dialogueManger.ProceedDialogue(isKeeping:true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0-1.csv",isKeeping:true);
                    }
                    else if (choiceNum == 2)
                    {
                        dialogueManger.ProceedDialogue(isKeeping:true);
                        dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0-2.csv",isKeeping:true);
                    }
                }
                else if(fileNum == 1)
                {
                    dialogueManger.ProceedDialogue(isKeeping:true);
                    dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0-2.csv",isKeeping:true);
                }
            }
            
        }
        
    }
    
}

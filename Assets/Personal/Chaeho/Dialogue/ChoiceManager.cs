using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choice
{
    private string myDefault = "";
    
    public int choices;

    public string c1, c2, c3;
    public string c1to, c2to, c3to;

    public Choice(
        string choices,
        string c1, string c2, string c3,
        string c1to, string c2to, string c3to)
    {
        this.choices = choices == myDefault ? -1 : int.Parse(choices);
        this.c1 = c1; this.c2 = c2; this.c3 = c3;
        this.c1to = c1to; this.c2to = c2to; this.c3to = c3to;
    }
        
}

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private DialogueManger dialogueManger;
    
    [SerializeField] private GameObject[] choiceObject;
    [SerializeField] private GameObject[] buttonObject;
    [SerializeField] private TMP_Text[] buttonText;

    private Choice currentChoice;

    public void InitChoice()
    {
        for (int i = 0; i < buttonObject.Length; i++)
        {
            buttonObject[i].SetActive(false);
        }

        for (int i = 0; i < choiceObject.Length; i++)
        {
            choiceObject[i].SetActive(false);
        }
        
        for (int i = 0; i < buttonText.Length; i++)
        {
            buttonText[i].text = "";
        }
        
    }
    
    public void StartChoice(string choiceAdress="")
    {
        if (choiceAdress == "")
        {
            Debug.LogError("ChoiceManager : no adress in start. check adress.");
            return;
        }
        print($"초이스 매니저: {choiceAdress}");
        
        GenerateChoice(choiceAdress);


        if (currentChoice.choices == 2 || currentChoice.choices == 3)
        {
            ShowChoice();
        }
        else
        {
            Debug.LogError("ChoiceManager : 'choices' is only can be 2 or 3");
            return;
        }
    }

    void GenerateChoice(string choiceAdress)
    {
        List<Dictionary<string, object>> csvData;
        csvData = CSVReader.Read(choiceAdress);

        string choices, c1, c2, c3, c1to, c2to, c3to;

            choices = csvData[0]["choices"].ToString();
        c1 = csvData[0]["c1"].ToString();
        c2 = csvData[0]["c2"].ToString();
        c3 = csvData[0]["c3"].ToString();
        c1to = csvData[0]["c1to"].ToString();
        c2to = csvData[0]["c2to"].ToString();
        c3to = csvData[0]["c3to"].ToString();

        currentChoice = new Choice(choices: choices, 
            c1: c1, c2: c2, c3: c3, 
            c1to: c1to, c2to: c2to, c3to: c3to);
    }

    void ExitChoice()
    {
        dialogueManger.isChoosing = false;
        for (int i = 0; i < buttonText.Length; i++)
        {
            buttonText[i].text = "";
        }
        for (int i = 0; i < buttonObject.Length; i++)
        {
            buttonObject[i].SetActive(false);
        }
        for (int i = 0; i < choiceObject.Length; i++)
        {
            choiceObject[i].SetActive(false);
        }
    }
    
    void ShowChoice()
    {
        for (int i = 0; i < choiceObject.Length; i++)
        {
            choiceObject[i].SetActive(true);
        }
        for (int i = 0; i < currentChoice.choices; i++)
        {
            buttonObject[i].SetActive(true);
        }

        buttonText[0].text = currentChoice.c1;
        buttonText[1].text = currentChoice.c2;
        buttonText[2].text = currentChoice.c3;
    }
    
    public void ClickBtn1()
    {
        ExitChoice();
        print("선택지1 클릭");
        //게임 매니저에 전달
    }

    public void ClickBtn2()
    {
        ExitChoice();
        print("선택지2 클릭");
        //게임 매니저에 전달
    }

    public void ClickBtn3()
    {
        ExitChoice();
        print("선택지3 클릭");
        //게임 매니저에 전달
    }
}

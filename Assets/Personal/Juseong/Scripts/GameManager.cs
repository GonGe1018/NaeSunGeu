using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int week = 1;
    int hp = 100;

    int[] heroines = new int[4]; //0:RG, 1:Zero, 2:Wop, 3:Ed

    int window = 0;


    public bool autoSkip = false;
    public bool autoPlay = false;

    [SerializeField] private DialogueManger dialogueManger;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Choosen(string str) //선택지에 따른 값 수정 (회의 후 수정예정)
    {
        string[] values = str.Split('_');
        int heroineID, value;
        switch (values[0])
        {
            case "RG": heroineID = 0;  break;
            case "Zero": heroineID = 1; break;
            case "Wop": heroineID = 2; break;
            case "Ed": heroineID = 3; break;
            default: return;
        }

        value = int.Parse(values[2]);
        SetLove(heroineID, value);
    }

    int SetHP(int value) //체력 증감 함수
    {
        if (hp + value < 0) return 1;

        hp += value;
        if (hp >= 100) { hp = 100; }
        return 0;
    }

    void SetLove(int heroineID, int value) //호감도 증감 함수
    {
        heroines[heroineID] += value;
        if (heroines[heroineID] < 0) { heroines[heroineID] = 0; }
        else if (heroines[heroineID] > 100 ) { heroines[heroineID] = 100; }
    }

    public void Home()
    {
        
    }
    public void Map()
    {
        
    }
    public void Setting()
    {
        
    }
    public void Profile()
    {
        
    }
}

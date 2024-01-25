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

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Choosen(string str) //선택지에 따른 값 수정 (회의 후 수정예정)
    {
        string[] datas = str.Split('_'); //히로인ID_호감도 변경 값_그외.. ('_(언더바)'로 데이터 값을 나누는 방식

        int heroineID,
            love;
        
        if (datas[0] != string.Empty) //히로인 ID값 가져오기
        {
            heroineID = int.Parse(datas[0]);
        }

        if (datas[1] != string.Empty) //호감도 변경 값 가져오기
        {
            love = int.Parse(datas[1]);
        }

        //그 외 변경사항 (추가예정)


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

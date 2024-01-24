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

    public void Choosen(string str) //�������� ���� �� ���� (ȸ�� �� ��������)
    {
        string[] datas = str.Split('_'); //������ID_ȣ���� ���� ��_�׿�.. ('_(�����)'�� ������ ���� ������ ���

        int heroineID,
            love;
        
        if (datas[0] != string.Empty) //������ ID�� ��������
        {
            heroineID = int.Parse(datas[0]);
        }

        if (datas[1] != string.Empty) //ȣ���� ���� �� ��������
        {
            love = int.Parse(datas[1]);
        }

        //�� �� ������� (�߰�����)


    }

    int SetHP(int value) //ü�� ���� �Լ�
    {
        if (hp + value < 0) return 1;

        hp += value;
        if (hp >= 100) { hp = 100; }
        return 0;
    }

    void SetLove(int heroineID, int value) //ȣ���� ���� �Լ�
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*������ �� ȣ����*/
    private int RG = 0, ZR = 0, IW = 0, ED = 0;



    public int getRG
    {
        get { return RG; }
        set { RG = value; }
    }
    public int getZR
    {
        get { return ZR; }
        set { ZR = value; }
    }
    public int getIW
    {
        get { return IW; }
        set { IW = value; }
    }
    public int getED
    {
        get { return ED; }
        set { ED = value; }
    }
    //-------------------



    protected int week = 1;
    public int WEEK
    {
        get { return week; } set { week = value; }
    }
    public int hp = 100;

    int[] heroines = new int[4]; //0:RG, 1:Zero, 2:Wop, 3:Ed

    //int window = 0;

    public GameObject UI_Container;//UI�����ִ� ���ӿ�����Ʈ
    Upper_Bar upper_Bar;


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
        //UI ��� ��������
        upper_Bar = UI_Container.GetComponent<Upper_Bar>();
    }

    
    void Update()
    {

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start_Scene");
    }
    
    
    // public void Choosen(string str) //�������� ���� �� ���� (ȸ�� �� ��������)
    // {
    //     string[] datas = str.Split('_'); //������ID_ȣ���� ���� ��_�׿�.. ('_(�����)'�� ������ ���� ������ ���
    //
    //     int heroineID,
    //         love;
    //
    //     if (datas[0] != string.Empty) //������ ID�� ��������
    //     {
    //         heroineID = int.Parse(datas[0]);
    //     }
    //
    //     if (datas[1] != string.Empty) //ȣ���� ���� �� ��������
    //     {
    //         love = int.Parse(datas[1]);
    //     }
    //
    //     //�� �� ������� (�߰�����)
    //
    //
    // }




    int SetHP(int value) //ü�� ���� �Լ�
    {
        if (hp + value < 0) return 1;

        hp += value;
        if (hp >= 100) { hp = 100; }


        //UI ��ȯ
        upper_Bar.HealthChange();

        return 0;
    }



    public void SetLove(string ID, int val)
    {
        //RG1 ZR2 IW3 ED4
        switch (ID)
        {
            case "RG":
                RG += val;

                break; 
            case "ZR":
                ZR += val;
                break;
            case "IW":
                IW += val;

                break;
            case "ED":
                ED += val;
                break;
        }
    }

    // public void Home()
    // {

    //}
    // public void Map()
    //{

    // }
    // public void Setting()
    // {

    // }
    //public void Profile()
    //{

    //}
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*히로인 별 호감도*/
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

    public GameObject UI_Container;//UI갖고있는 게임오브젝트
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



        //UI 요소 가져오기
        upper_Bar = UI_Container.GetComponent<Upper_Bar>();
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


        //UI 변환
        upper_Bar.HealthChange();

        return 0;
    }



    public void setLove(string ID, int val)
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

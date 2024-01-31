using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Map : MonoBehaviour
{
    private VisualElement root, map;
    private Button[] buttons= new Button[6];
    [SerializeField]  GameManager gameManager;
    [SerializeField] DialogueManger dialogueManger;
    [SerializeField] Upper_Bar upper_bar;   

   // private bool[] loveCount = new bool[6];

    private bool[] storyCount= new bool[6];

    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        map = root.Q<VisualElement>("Map_Bottom");
        MapIn();

        buttons[0] = root.Q<Button>("loc1");//1
        buttons[1] = root.Q<Button>("loc2");
        buttons[2] = root.Q<Button>("loc3");
        buttons[3] = root.Q<Button>("loc4");//4호관
        buttons[4] = root.Q<Button>("loc5");//기숙사
        buttons[5] = root.Q<Button>("loc6");//운동장

        for (int i = 0; i < 6; i++)
        {
            storyCount[i] = false;
            buttons[i].RegisterCallback<ClickEvent>(OnButtonClicked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MapOut()
    {
        map.AddToClassList("Map_Out");
    }
    public void MapIn()
    {
        map.RemoveFromClassList("Map_Out");
    }

    private void OnButtonClicked(ClickEvent evt)
    {
        switch ((evt.target as Button).name)
        {
            case "loc1":
                //1호관 클릭시
                print("1호관 테스트");

                if ((gameManager.WEEK == 1)&& !storyCount[0])
                {
                    dialogueManger.StartDialogue("DialogueCSV/Week1/loc1/dlg0.csv");
                    storyCount[0]=true;
                }
                else if ((gameManager.WEEK == 2)&& !storyCount[0])
                {
                    dialogueManger.StartDialogue("DialogueCSV/Week2/loc1/dlg0.csv");
                    storyCount[0] = true;
                }
                break;

            case "loc2":
                //2호관 클릭시

                  if ((gameManager.WEEK == 2) && !storyCount[1])
                {
                    dialogueManger.StartDialogue("DialogueCSV/Week2/loc2/dlg0.csv");
                    storyCount[0] = true;
                }
                break;

            case "loc3":
                //3호관 클릭시
                if ((gameManager.WEEK == 2) && !storyCount[2])
                {
                    dialogueManger.StartDialogue("DialogueCSV/Week2/loc3/dlg0.csv");
                    storyCount[0] = true;
                }
                break;

            case "loc4":
                //4호관 클릭시

                if ((gameManager.WEEK == 1) && !storyCount[3] )
                {
                    dialogueManger.StartDialogue("DialogueCSV/Week1/loc4/dlg0.csv");
                    storyCount[3]=true;
                }
                if ((gameManager.WEEK == 2) && !storyCount[3])
                {
                    dialogueManger.StartDialogue("DialogueCSV/Week2/loc4/dlg0.csv");
                    storyCount[0] = true;
                }
                break;

            case "loc5":
                //기숙사
                break;

            case "loc6":
                //운동장
                if ((gameManager.WEEK == 1) && !storyCount[5])
                { dialogueManger.StartDialogue("DialogueCSV/Week1/loc6/dlg0.csv");
                    storyCount[5]=true;
                }
                break;


        }


        if((gameManager.WEEK == 1) && storyCount[0]&&storyCount[3] && storyCount[5]){ 
        gameManager.WEEK = 2;
            storyCount[0]=false;
            storyCount[3] = false;
            storyCount[5]=false;
            upper_bar.WeekChange();
        }
        
    }
}

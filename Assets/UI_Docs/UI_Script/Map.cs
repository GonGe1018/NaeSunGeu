using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Map : MonoBehaviour
{
    private VisualElement root, map;
    private Button[] buttons= new Button[6];

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
            buttons[i].RegisterCallback<ClickEvent>(OnButtonClicked);
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
        switch((evt.target as Button).name)
        {
            case "loc1":
                //1호관 클릭시
                print("1호관 테스트");
                break;

            case "loc2":
                //2호관 클릭시
                break;

            case "loc3":
                //3호관 클릭시
                break;

            case "loc4":
                //4호관 클릭시
                break;

            case "loc5":
                //기숙사
                break;

            case "loc6":
                //운동장
                break;
        }
        
    }
}

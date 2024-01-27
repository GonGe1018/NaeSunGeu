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
        buttons[3] = root.Q<Button>("loc4");//4ȣ��
        buttons[4] = root.Q<Button>("loc5");//�����
        buttons[5] = root.Q<Button>("loc6");//���

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
                //1ȣ�� Ŭ����
                print("1ȣ�� �׽�Ʈ");
                break;

            case "loc2":
                //2ȣ�� Ŭ����
                break;

            case "loc3":
                //3ȣ�� Ŭ����
                break;

            case "loc4":
                //4ȣ�� Ŭ����
                break;

            case "loc5":
                //�����
                break;

            case "loc6":
                //���
                break;
        }
        
    }
}

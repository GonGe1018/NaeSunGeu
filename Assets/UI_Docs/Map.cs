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

        for(int i = 0;i<6;i++)
        {
            buttons[i] = map[i].Q<Button>();
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
}

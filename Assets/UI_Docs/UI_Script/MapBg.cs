
using UnityEngine;
using UnityEngine.UIElements;

public class MapBg : MonoBehaviour
{
    private VisualElement root, map;
    private Button[] buttons= new Button[6];

    // Start is called before the first frame update
    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        map = root.Q<VisualElement>("Map_Bottom");
        MapIn();


      
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

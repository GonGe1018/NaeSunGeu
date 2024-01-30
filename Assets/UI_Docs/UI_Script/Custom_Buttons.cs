using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Custom_Buttons : MonoBehaviour
{
    private VisualElement root;
    public Button[] Setting_buttons = new Button[5];
    public GameObject ForMap,ForSet,ForProf, ForMapBg ; Map Mapinst; Prof Profinst; MapBg mapBg;
    


    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Setting_buttons[0] = root.Q<Button>("Settings");
        Setting_buttons[1] = root.Q<Button>("Map");
        Setting_buttons[2] = root.Q<Button>("Home");
        Setting_buttons[3] = root.Q<Button>("Endings");
        Setting_buttons[4] = root.Q<Button>("Profile");
        ForSet.SetActive(false);
        
        
         Mapinst= ForMap.GetComponent<Map>();
        Profinst=ForProf.GetComponent<Prof>();
        mapBg=ForMapBg.GetComponent<MapBg>();
        for (int i = 0; i < 5; i++)
        {
            // Setting_buttons[i].RegisterCallback<ClickEvent>(OnSettingButtonClick);
            Setting_buttons[i].RegisterCallback<ClickEvent>(OnSettingButtonClick);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /// private void MapClick()
   // {
    //    Map.AddToClassList("Map_Out");
  //  }


    private void OnSettingButtonClick(ClickEvent evt)
    {
        string buttonName;
        IMGUIContainer imguiContainer;
        Button clickedButton = evt.target as Button;
        if (clickedButton != null)
        {
            buttonName = clickedButton.name;

            for (int i = 0; i < 5; i++)
            {
                if (Setting_buttons[i].name != buttonName)
                {
                    Setting_buttons[i].AddToClassList("Button_Unclick");
                    imguiContainer = Setting_buttons[i].Q<IMGUIContainer>();
                     imguiContainer.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
                   

                }
                else
                {
                    clickedButton.RemoveFromClassList("Button_Unclick");
                    imguiContainer = Setting_buttons[i].Q<IMGUIContainer>();
                    imguiContainer.style.unityBackgroundImageTintColor = new Color(1f, 0f, 1f, 0.6f);
                    if (buttonName == "Map")
                    {
                        Mapinst.MapOut();
                        mapBg.MapOut();
                    }
                    

                    else
                    {
                        Mapinst.MapIn();
                        mapBg.MapIn();
                    }


                    if(buttonName=="Settings")
                        ForSet.SetActive(true);
                    if (buttonName == "Profile")
                    {
                        Profinst.ProfIn();
                    }
                    else
                    { 
                        Profinst.ProfOut();
                    }
                }
            }
            print(buttonName);
        }
        else buttonName = "NULL";


      //  if (buttonName == "Map")
           // MapClick();
   
    }



}

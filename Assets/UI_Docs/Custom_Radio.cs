using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Custom_Radio : MonoBehaviour
{
    private VisualElement root;
    private VisualElement Story, Touch;

    private Button Exit;

    private Button[] StoryB=new Button[2], TouchB = new Button[2];

    // Start is called before the first frame update
    void OnEnable()
    {
        root=GetComponent<UIDocument>().rootVisualElement;
        Story=root.Q<VisualElement>("Story");
        Touch = root.Q<VisualElement>("Touch");
        
        StoryB[0] = Story.Q<Button>("StorySkip_off");
        StoryB[1] = Story.Q<Button>("StorySkip_on");


        TouchB[0] = Touch.Q<Button>("TouchSkip_off");
        TouchB[1] = Touch.Q<Button>("TouchSkip_on");

        Exit= root.Q<Button>("ExitB");

        Exit.RegisterCallback<ClickEvent>(ExitSettings);


        StoryB[0].RegisterCallback<ClickEvent>(BtnClck);
        StoryB[1].RegisterCallback<ClickEvent>(BtnClck);
         TouchB[0].RegisterCallback<ClickEvent>(BtnClck);
        TouchB[1].RegisterCallback<ClickEvent>(BtnClck);



    }

    

 
    // Update is called once per frame
    void Update()
    {
        
    }


    private void BtnClck(ClickEvent evt)
    {
        //  print(evt.target);
        Button button;
        VisualElement Parent;

        button =evt.target as Button;
         Parent= button.parent;

            if (Parent.name=="Story")
            {
            button.AddToClassList("radio_on");
           // button.text = ("ÄÑ±â");
                if (StoryB[0].name==button.name)
                {
                StoryB[1].RemoveFromClassList("radio_on");
              //  StoryB[1].text = ("²ô±â");
                }
            else
            {
                StoryB[0].RemoveFromClassList("radio_on");
                //StoryB[0].text = ("²ô±â");
            }

         }


        else if (Parent.name == "Touch")
        {
            button.AddToClassList("radio_on");
           // button.text = ("ÄÑ±â");
            if (TouchB[0].name == button.name)
            {
                TouchB[1].RemoveFromClassList("radio_on");
               // TouchB[1].text = ("²ô±â");
            }
            else
            {
                TouchB[0].RemoveFromClassList("radio_on");
               // TouchB[0].text = ("²ô±â");
            }

        }


        // if (!button.ClassListContains("radio_on"))
        // {
        //     button.AddToClassList("radio_on");

        //      button.text=("ÄÑ±â");
        // }
        //else
        // {
        //    button.RemoveFromClassList("radio_on");
        //    button.text = "²ô±â";
        // }

    }


   // private void OnButtonClicked(OnButtonClick e)
   // {
   //     int me = 0;
    //    if(this!=this.transform.parent.GetChild(0))
   //     {
   //         me = 1;
  //      }

  //      if(this.) { }
 //   }

    private void ExitSettings(ClickEvent evt) 
    {
        gameObject.SetActive(false);
    }

}

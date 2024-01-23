using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Custom_Slider : MonoBehaviour
{
    private VisualElement m_Root;
    //root

    private SliderInt Bgm_slider,Effct_Slider;

    private VisualElement Bgm_Dragger,Effct_Dragger;

    private VisualElement Bgm_Bar, Bgm_Head,Effct_Bar,Effct_Head;

    // Start is called before the first frame update
    void OnEnable()
    {
        //get references to necesarra
        m_Root = GetComponent<UIDocument>().rootVisualElement;
        Bgm_slider = m_Root.Q<SliderInt>("Bgm_Slider");
        Effct_Slider=m_Root.Q<SliderInt>("Effct_Slider");
        if(Bgm_slider==null)
        {
            print("Bgm슬라이더없음");
        }
        else if (Effct_Slider==null)
        {
            print("Efct슬라이더없음");
        }

        Bgm_Dragger = Bgm_slider.Q<VisualElement>("unity-dragger");
        Effct_Dragger = Effct_Slider.Q<VisualElement>("unity-dragger");

        if (Bgm_slider == null)
        {
            print("Bgm드래거없음");
        }
        else if (Effct_Slider == null)
        {
            print("Efct드래거없음");
        }


        Debug.Log(Bgm_slider);
        AddElements();

        Bgm_slider.RegisterCallback<ChangeEvent<int>>(OnValueChange_Int);
        Effct_Slider.RegisterCallback<ChangeEvent<int>>(OnValueChange_Int);


    }


    
    private void OnValueChange_Int(ChangeEvent<int> evt)
    {
      //  m_Bar.style.width = m_Slider.value;
     //   Debug.Log(value);
    }

    void AddElements()
    {
        Bgm_Bar = new VisualElement();
        Bgm_Head=new VisualElement();
        Bgm_Dragger.Add(Bgm_Bar);
        Bgm_Bar.name = "Bar";
        Bgm_Bar.AddToClassList("Bar");


        Effct_Bar = new VisualElement();
        Effct_Head = new VisualElement();
        Effct_Dragger.Add(Effct_Bar);
        Effct_Bar.name = "Bar";
        Effct_Bar.AddToClassList("Bar");
    }

 



    // Update is called once per frame
    void Update()
    {
        
    }
}

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

    private SliderInt m_Slider;

    private VisualElement m_Dragger;

    private VisualElement m_Bar, m_Head;

    // Start is called before the first frame update
    void Start()
    {
        //get references to necesarra
        m_Root = GetComponent<UIDocument>().rootVisualElement;
        m_Slider = m_Root.Q<SliderInt>("MySlider");
        m_Dragger = m_Root.Q<VisualElement>("unity-dragger");

        Debug.Log(m_Slider);
        AddElements();

        m_Slider.RegisterCallback<ChangeEvent<int>>(OnValueChange_Int);
    }


    
    private void OnValueChange_Int(ChangeEvent<int> evt)
    {
      //  m_Bar.style.width = m_Slider.value;
        Debug.Log(m_Slider.value);
    }

    void AddElements()
    {
        m_Bar = new VisualElement();
        m_Head=new VisualElement();
        m_Dragger.Add(m_Bar);
        m_Bar.name = "Bar";
        m_Bar.AddToClassList("Bar");
    }

 



    // Update is called once per frame
    void Update()
    {
        
    }
}

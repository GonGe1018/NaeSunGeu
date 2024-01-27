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

    private SliderInt bgmSlider, effctSlider;


    [SerializeField] SoundManager soundManager;

    public int BgmValue
    {
        get {return bgmSlider.value; }
        set { bgmSlider.value = value;}
    }
    public int EffectValue
    {
    get { return effctSlider.value; }
        set { effctSlider.value = value;}
    }
    private VisualElement Bgm_Dragger,Effct_Dragger;

    private VisualElement Bgm_Bar, Bgm_Head,Effct_Bar,Effct_Head;

    // Start is called before the first frame update
    void OnEnable()
    {
        //get references to necesarra
        m_Root = GetComponent<UIDocument>().rootVisualElement;
        bgmSlider = m_Root.Q<SliderInt>("Bgm_Slider");
        effctSlider=m_Root.Q<SliderInt>("Effct_Slider");
        if(bgmSlider==null)
        {
            print("Bgm슬라이더없음");
        }
        else if (effctSlider==null)
        {
            print("Efct슬라이더없음");
        }

        Bgm_Dragger = bgmSlider.Q<VisualElement>("unity-dragger");
        Effct_Dragger = effctSlider.Q<VisualElement>("unity-dragger");

        if (bgmSlider == null)
        {
            print("Bgm드래거없음");
        }
        else if (effctSlider == null)
        {
            print("Efct드래거없음");
        }


        Debug.Log(bgmSlider);
        AddElements();

        bgmSlider.RegisterCallback<ChangeEvent<int>>(OnValueChange_Int);
        effctSlider.RegisterCallback<ChangeEvent<int>>(OnValueChange_Int);

        bgmSlider.value = ((int)(soundManager.bgmsound * 100f));
        effctSlider.value = ((int)(soundManager.effectsound * 100f));
    }


    
    private void OnValueChange_Int(ChangeEvent<int> evt)
    {
        //  m_Bar.style.width = m_Slider.value;
        //   Debug.Log(value);

        soundManager.bgmsound = bgmSlider.value/100f;
        soundManager.effectsound = effctSlider.value/100f;
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


}

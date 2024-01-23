using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Prof : MonoBehaviour
{
    VisualElement root, profile;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        root= GetComponent<UIDocument>().rootVisualElement;
        profile= root.Q<VisualElement>("Pro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProfIn()
    {
        profile.AddToClassList("Prof_In");
    }

    public void ProfOut()
    {
        profile.RemoveFromClassList("Prof_In");
    }
}

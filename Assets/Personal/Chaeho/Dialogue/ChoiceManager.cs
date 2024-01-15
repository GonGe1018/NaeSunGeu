using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private GameObject[] choiceObject;

    [SerializeField] private TMP_Text[] twoBtnText;
    [SerializeField] private TMP_Text[] thrBtnText;
    
    public void startChoice(string choiceAdress="")
    {
        if (choiceAdress == "")
        {
            Debug.LogError("ChoiceManager : no adress in start. check adress.");
            return;
        }
        
    }
}

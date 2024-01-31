
using UnityEngine;
using UnityEngine.UIElements;

public class Prof : MonoBehaviour
{
    VisualElement root, profile;
    VisualElement[] cha=new VisualElement[4];
    [SerializeField] GameManager gameManager;

    
    // Start is called before the first frame update
    void OnEnable()
    {
        root= GetComponent<UIDocument>().rootVisualElement;
        profile= root.Q<VisualElement>("Pro");
        cha[0] = root.Q<VisualElement>("RG");
        cha[1] = root.Q<VisualElement>("ZR");
        cha[2] = root.Q<VisualElement>("IW");
        cha[3] = root.Q<VisualElement>("ED");

        //이제로, 최이왑, 정에드

        cha[0].Q<TextElement>("Name").text = "김알지";
        cha[1].Q<TextElement>("Name").text = "이제로";
        cha[2].Q<TextElement>("Name").text = "최이왑";
        cha[3].Q<TextElement>("Name").text = "정에드";

        cha[0].Q<TextElement>("Number").text = gameManager.getRG.ToString() + "%";
        cha[1].Q<TextElement>("Number").text = gameManager.getZR.ToString() + "%";
        cha[2].Q<TextElement>("Number").text = gameManager.getIW.ToString() + "%";
        cha[3].Q<TextElement>("Number").text = gameManager.getED.ToString() + "%";

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProfIn()
    {
        profile.AddToClassList("Prof_In");
        cha[0].Q<TextElement>("Number").text = gameManager.getRG.ToString() + "%";
        cha[1].Q<TextElement>("Number").text = gameManager.getZR.ToString() + "%";
        cha[2].Q<TextElement>("Number").text = gameManager.getIW.ToString() + "%";
        cha[3].Q<TextElement>("Number").text = gameManager.getED.ToString() + "%";
    }

    public void ProfOut()
    {
        profile.RemoveFromClassList("Prof_In");
       // gameObject.SetActive(false);
    }
}

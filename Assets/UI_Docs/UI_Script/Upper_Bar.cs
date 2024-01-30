using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Upper_Bar : MonoBehaviour
{
    private VisualElement root;
    public TextElement[] UpTexts = new TextElement[2];
    int week, health;
    GameManager gameManager;
    public GameObject GM_container;

    // Start is called before the first frame update
    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        UpTexts[0] = root.Q<TextElement>("Ftext");
        UpTexts[1] = root.Q<TextElement>("Stext");

        if (UpTexts[0] == null) print("0");
        if (UpTexts[1] == null) print("1");

        gameManager = GM_container.GetComponent<GameManager>();
        if(gameManager==null)print("gm missing");

    }

    private void Start()
    {
        week = gameManager.WEEK;
        health = gameManager.hp;

        WeekChange();
        HealthChange();
    }

    // Update is called once per frame

    public void WeekChange ()
    {
        week = gameManager.WEEK;
        health = gameManager.hp;
        UpTexts[0].text = "week "+week.ToString();
    }

    public void HealthChange()
    {
        UpTexts[1].text = health.ToString();
    }

}


using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Start_UI : MonoBehaviour
{

    VisualElement root,startvis,logo,White;

    Button load, start, exit;

    private void Awake()
    {
       // Screen.SetResolution(1080, 1920, false);
    }

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startvis = root.Q<VisualElement>("StartVis");
        logo = root.Q<VisualElement>("Logo");
        White=root.Q<VisualElement>("White");

        load = root.Q<Button>("Load");
        start = root.Q<Button>("Start");
        exit = root.Q<Button>("Exit");


        load.RegisterCallback<ClickEvent>(LoadGame);
        start.RegisterCallback<ClickEvent>(StartGame);
        exit.RegisterCallback<ClickEvent>(ExitGame);

        White.RemoveFromClassList("Blank");

        Invoke("UIani", 1);
    }


    private void UIani()
    {
        White.AddToClassList("Blank");
        logo.RemoveFromClassList("Logo_In");
        load.RemoveFromClassList("B_Out");
        startvis.AddToClassList("Start_In");
        exit.RemoveFromClassList("B_Out");
    }


    void StartGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Home_Scene");
    }
    void ExitGame(ClickEvent evt)
    {
        Application.Quit();
        // #if UNITY_EDITOR
        //         UnityEditor.EditorApplication.isPlaying = false;
        // #else
        //         Application.Quit(); // 어플리케이션 종료
        // #endif
    }
    private void LoadGame(ClickEvent evt)
    {
            
        //여기에 로드 넣기 

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Button bgmon, bgmoff;
    public bool on = false;

   // public Button mute;

    [SerializeField] private float BGMSound = 0.2f;
    public float bgmsound
   {
        get { return BGMSound; }
        set { BGMSound = value; }   
    }
       [SerializeField] private float  effectSound = 0.2f;


    public float effectsound
    {
        get { return effectSound; }
        set { effectSound = value; }
    }
    //---------------------------------------BGM이랑 이펙트 크기 설정 



    [SerializeField] private Custom_Slider customSlider; 
//--------------슬라이더 값(크기)가져오게 설정함 ------------


    public static SoundManager instance;

    //배경음악 하나 키보드 하나

    [SerializeField] private GameObject[] bgmHandler;
    [SerializeField] private GameObject[] sfxHandler ;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        BGMvolume(BGMSound);

    }

    private void Start()
    {

      //  customSlider.BgmValue = ((int)(BGMSound*100f));
       // customSlider.EffectValue = ((int)(effectSound*100f));
//설정창 열리면 

        
   
    }


    public void BGMvolume(float val) //BGM 음량 조절 함수 (0 <= val <= 1)
    {
        for (int i = 0; i < bgmHandler.Length; i++)
        { bgmHandler[0].GetComponent<AudioSource>().volume = val; }

    }
  
    public void buttonMute ()
    {
        if(on)
        {
            BGMStop(0);
            on = !on;
        }
         else
        {
        BGMStart(0);
            on = !on;
        }
    }

    public void BGMStop(int i) //BGM 정지 인덱스값 받아와서 i번째 bgm 멈춤 
    {
        //i번 BGM 멈춤 
        
        bgmHandler[i].GetComponent<AudioSource>().Stop();
       
    }

    public void BGMStart(int i)
    {
        bgmHandler[i].GetComponent<AudioSource>().Play();
       
    }

    public void SFXvolume(float val) //BGM 음량 조절 함수 (0 <= val <= 1)
    {
        for (int i = 1; i < sfxHandler.Length; i++)
        {
            sfxHandler[i].GetComponent<AudioSource>().volume = val;
        }

    }

    public void SFXStop(int i) //BGM 정지 인덱스값 받아와서 i번째 bgm 멈춤 
    {
        //i번 sfx 멈춤 

        sfxHandler[i].GetComponent<AudioSource>().Stop();
    }

    public void SFXStart(int i)
    {
        sfxHandler[i].GetComponent<AudioSource>().Play();
    }


    /*
      public void SFXPlay(int SFXId) //효과음 재생
      {
          switch (SFXId)
          {
              case 0: BGMSource.clip = SFX1; break;
              default: print("SoundManager에 잘못된 값이 입력됨"); break;
          }
          SFXSource.Play();
      }

      public void SFXStop() //효과음 정지
      {
          SFXSource.Stop();
          SFXSource.clip = null;
      }*/
}

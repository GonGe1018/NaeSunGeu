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
    //---------------------------------------BGM�̶� ����Ʈ ũ�� ���� 



    [SerializeField] private Custom_Slider customSlider; 
//--------------�����̴� ��(ũ��)�������� ������ ------------


    public static SoundManager instance;

    //������� �ϳ� Ű���� �ϳ�

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
//����â ������ 

        
   
    }


    public void BGMvolume(float val) //BGM ���� ���� �Լ� (0 <= val <= 1)
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

    public void BGMStop(int i) //BGM ���� �ε����� �޾ƿͼ� i��° bgm ���� 
    {
        //i�� BGM ���� 
        
        bgmHandler[i].GetComponent<AudioSource>().Stop();
       
    }

    public void BGMStart(int i)
    {
        bgmHandler[i].GetComponent<AudioSource>().Play();
       
    }

    public void SFXvolume(float val) //BGM ���� ���� �Լ� (0 <= val <= 1)
    {
        for (int i = 1; i < sfxHandler.Length; i++)
        {
            sfxHandler[i].GetComponent<AudioSource>().volume = val;
        }

    }

    public void SFXStop(int i) //BGM ���� �ε����� �޾ƿͼ� i��° bgm ���� 
    {
        //i�� sfx ���� 

        sfxHandler[i].GetComponent<AudioSource>().Stop();
    }

    public void SFXStart(int i)
    {
        sfxHandler[i].GetComponent<AudioSource>().Play();
    }


    /*
      public void SFXPlay(int SFXId) //ȿ���� ���
      {
          switch (SFXId)
          {
              case 0: BGMSource.clip = SFX1; break;
              default: print("SoundManager�� �߸��� ���� �Էµ�"); break;
          }
          SFXSource.Play();
      }

      public void SFXStop() //ȿ���� ����
      {
          SFXSource.Stop();
          SFXSource.clip = null;
      }*/
}

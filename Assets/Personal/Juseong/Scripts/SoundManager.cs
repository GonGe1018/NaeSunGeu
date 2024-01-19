using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource SFXSource;

    [SerializeField] private float BGMSound = 0.5f;
    [SerializeField] private float effectSound = 0.5f;

    [SerializeField] private AudioClip BGM1; //배경음1
    [SerializeField] private AudioClip SFX1; //효과음1


    public void BGMvolume(float val) //BGM 음량 조절 함수 (0 <= val <= 1)
    {
        mixer.SetFloat("BGM", Mathf.Log10(val) * 20);
    }

    public void BGMPlay(int BGMId) //BGM 재생
    {
        switch (BGMId)
        {
            case 0: BGMSource.clip = BGM1; break;
            default: print("SoundManager에 잘못된 값이 입력됨"); break;
        }
        BGMSource.Play();
    }

    public void BGMStop() //BGM 정지
    {
        BGMSource.Stop();
        BGMSource.clip = null;
    }


    public void SFXvolume(float val) //효과음 음량 조절 함수 (0 <= val <= 1)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }

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
    }
}

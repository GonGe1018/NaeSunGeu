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

    [SerializeField] private AudioClip BGM1; //�����1
    [SerializeField] private AudioClip SFX1; //ȿ����1


    public void BGMvolume(float val) //BGM ���� ���� �Լ� (0 <= val <= 1)
    {
        mixer.SetFloat("BGM", Mathf.Log10(val) * 20);
    }

    public void BGMPlay(int BGMId) //BGM ���
    {
        switch (BGMId)
        {
            case 0: BGMSource.clip = BGM1; break;
            default: print("SoundManager�� �߸��� ���� �Էµ�"); break;
        }
        BGMSource.Play();
    }

    public void BGMStop() //BGM ����
    {
        BGMSource.Stop();
        BGMSource.clip = null;
    }


    public void SFXvolume(float val) //ȿ���� ���� ���� �Լ� (0 <= val <= 1)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }

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
    }
}

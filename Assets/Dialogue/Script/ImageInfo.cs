using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ImageType//이미지 타입
{
    None,
    StandIllust,
    Background,
    Item
};

public class ImageInfo : MonoBehaviour 
{
    [SerializeField] ImageType imageType;
    private void Awake() {
        GameObject Image = gameObject;
        Image.SetActive(false);//비활성화
    }
    
}

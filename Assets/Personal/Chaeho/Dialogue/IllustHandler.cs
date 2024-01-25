using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllustHandler : MonoBehaviour
{
    [SerializeField] IllustInfo[] illustInfo;//캐릭터 일러스트
    public GameObject[,] illusts; //일러스트를 세분화한 배열 [캐릭터 종류, 캐릭터의 표정이나 상태]
                                                         ///예를 들어 같은 캐릭터라도 표정이 다르거나 상태가 다른 경우
                                                         /// 예를 들어 같은 아이템이라도 상태가 다른 경우
                                                         /// 0번은 기본 일러
    
    private void Awake()
    {
        illusts = new GameObject[illustInfo.Length, 6];
        for (int i = 0; i < illustInfo.Length; i++) {
            for (int j = 0; j < illustInfo[i].categoriArr.Length; j++)
            {
                illusts[i, j] = illustInfo[i].categoriArr[j];
            }
        } 
    }
}

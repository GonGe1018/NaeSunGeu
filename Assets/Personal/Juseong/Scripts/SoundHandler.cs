using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{


    public GameObject[] Sounds = new GameObject[2];
    // Start is called before the first frame update

    public GameObject[] sounds
    {
        get { return Sounds; } // et { Sounds = value; }
    }
    

}

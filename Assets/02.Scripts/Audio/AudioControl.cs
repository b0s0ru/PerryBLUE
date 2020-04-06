using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioControl : MonoBehaviour
{
    static public Audios audios1;
    int a;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        a = SceneManager.GetActiveScene().buildIndex;
         audios1 = GameObject.Find("Audio Source").GetComponent<Audios>();
        if (a == 0)
        {
            i = 0;
            audios1.Audio2(0);
        }
        else if (a == 1)
        {
            i = 1;
            audios1.Audio2(2);
        }
       /* else if (a == 2)
        {
            i = 2;
            audios1.Audio2(i);
        }/*
        else if (a == 3)
        {
            i = 1;
            audios1.Audio2(i);
        }
        */

        // Update is called once per frame
    }
}

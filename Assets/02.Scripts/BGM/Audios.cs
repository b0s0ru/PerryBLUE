using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioClip[] bgm;

    public static Audios instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


    }
    // Start is called before the first frame update


    // Update is called once per frame
    public void Audio2(int i)
    {

        GetComponent<AudioSource>().clip = bgm[i];
        GetComponent<AudioSource>().Play();
    }



}

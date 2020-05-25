using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioClip[] bgm;

    public static Audios instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public static Audios Instance

    {

        get

        {

            if (instance == null)

            {

                var obj = FindObjectOfType<Audios>();

                if (obj != null)

                {

                    instance = obj;

                }

                else

                {

                    var newSingleton = new GameObject("Audiomanager").AddComponent<Audios>();

                    instance = newSingleton;

                }

            }

            return instance;

        }

        private set

        {

            instance = value;

        }

    }

    private void Awake()

    {

        var objs = FindObjectsOfType<Texts>();
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update

    public void Audio1()
    {
        GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    public void Audio2(int i)
    {

        GetComponent<AudioSource>().clip = bgm[i];
        GetComponent<AudioSource>().Play();
    }



}

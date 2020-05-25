using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioControl : MonoBehaviour
{

    int a;
    int i=-1;
    bool next = false;
    public static AudioControl instance;
    public AudioClip[] bgm;
    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode level)
    {

       
        a = SceneManager.GetActiveScene().buildIndex;
       
         if (a == 22 || a == 23 || a == 1 || a == 2)
        {
            if (i == 0)
            {
                next = true;
            }
            else
            {
                next = false;
            }
            i = 0;
           
        }
        else if (a == 24 || (a >= 3 && a<=11) || a==0)
        {
            if (i == 1)
            {
                next = true;
            }
            else
            {
                next = false;
            }
            i = 1;
           
        }else if(a>=12 && a <= 20)
        {
            if (i == 2)
            {
                next = true;
            }
            else
            {
                next = false;
            }
            i = 2;
        }
        if (!next)
        {
            Audio2(i);
            
        }
       
    }
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
    

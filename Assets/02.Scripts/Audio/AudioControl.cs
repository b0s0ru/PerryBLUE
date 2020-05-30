using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioControl : MonoBehaviour
{
    string bgmname = "dog";
    string changename = "1";
    int a;
   
    public static AudioControl instance;
   
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
            bgmname = "Wind";
            if (bgmname != changename)
            {
                Audio1(bgmname);

            }


        }
        else if (a == 24 || (a >= 3 && a <= 11) || a == 0)
        {
            bgmname = "ameno";
            if (bgmname != changename)
            {
                Audio1(bgmname);

            }

        }
        else if (a >= 12 && a <= 20)
        {
            bgmname = "kodoku";
            if (bgmname != changename)
            {
                Audio1(bgmname);

            }
        }


    }

    // Update is called once per frame
    public void Audio1(string name)
    {
        var singleton = SoundManager.Instance;
        singleton.ChangeBGM(name);
        changename = name;
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
    

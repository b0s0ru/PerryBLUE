using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
   
    
    int Scenenumber;
    // Start is called before the first frame update
    void Start()
    {
        Scenenumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    public void Scenemove()
    {
        Invoke("Scenemove", 0.2f);
        SceneManager.LoadScene(Scenenumber + 1);

        /*   if (PlayerPrefs.GetInt("level") < Scenenumber + 1)
           {
               PlayerPrefs.SetInt("level", Scenenumber + 1);
               PlayerPrefs.Save();
           }
           */


    }
}


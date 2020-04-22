using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScene : MonoBehaviour
{
    public int a = 0;
    // Update is called once per frame
    void Update()
    {
    }
    public void Sin()
    {
        
        PlayerPrefs.DeleteKey("map");
        SceneManager.LoadScene(a);

    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("map"))
        {
            a = PlayerPrefs.GetInt("map");
            SceneManager.LoadScene(a);
        }
        else
        {
            PlayerPrefs.DeleteKey("map");
            SceneManager.LoadScene(a);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScene : MonoBehaviour
{
    public int a = 0;
    FadeController black;
    // Update is called once per frame
    void Start()
    {
        black = GameObject.Find("Canvas").transform.Find("black").GetComponent<FadeController>();
    }
    public void Sin()
    {
        black.FadeIn(0.3f);
        PlayerPrefs.DeleteKey("map");
        StartCoroutine("Scenemove");
        

    }
    public void Load()
    {
        black.FadeIn(0.3f);
        StartCoroutine("Scenemove");
       
    }
    IEnumerator Scenemove()
    {
        yield return new WaitForSeconds(0.3f);
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

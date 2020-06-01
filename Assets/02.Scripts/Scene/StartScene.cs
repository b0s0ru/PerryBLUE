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
        black =  FadeController.instance.GetComponent<FadeController>();
    }
    public void Sin()
    {
        black.FadeIn(0.3f);
        PlayerPrefs.DeleteKey("map");
        for(int i=0; i<=1000; i++) {
            PlayerPrefs.DeleteKey("texts" + i);
        }
        PlayerPrefs.SetInt("test", 0);
        PlayerPrefs.Save();

        StartCoroutine("Scenemove");
        

    }
    public void Load()
    {
        black.FadeIn(0.3f);
        StartCoroutine("Scenemove");
        PlayerPrefs.SetInt("test", 0);
        PlayerPrefs.Save();

    }
    
    public void test(int a)
    {
        PlayerPrefs.SetInt("test", 1);
        PlayerPrefs.Save();
        GameObject b = Instantiate(Resources.Load("char/Player")) as GameObject;
        b.name = "Player";
        SceneManager.LoadScene(a);

    }
    public void Re()
    {
        Destroy(GameObject.Find("Player").gameObject);
        SceneManager.LoadScene(0);
        
    }
    IEnumerator Scenemove()
    {

        yield return new WaitForSeconds(0.3f);
        if (PlayerPrefs.HasKey("map"))
        {
            a = PlayerPrefs.GetInt("map");
            GameObject b= Instantiate(Resources.Load("char/Player"))as GameObject;
            b.name = "Player";
            SceneManager.LoadScene(a);
            
        }
        else
        {
            
            PlayerPrefs.SetString("keys", "Load1");
            PlayerPrefs.Save();
            SceneManager.LoadScene(22);
            
            
        }
    }
   
}

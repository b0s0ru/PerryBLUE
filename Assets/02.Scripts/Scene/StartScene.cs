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

        SceneManager.LoadScene(a);

    }
}

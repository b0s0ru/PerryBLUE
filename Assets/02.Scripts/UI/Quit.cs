using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void Quits()
    {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL("http://google.com");   
        #else
            Application.Quit();
        #endif
            
    }

}
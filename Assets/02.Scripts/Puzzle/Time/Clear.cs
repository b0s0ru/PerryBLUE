using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Clear : MonoBehaviour
{
    public int[] cd;
    public Changenumber[] d;
    bool win = false;
    public bool gameclaer = false;
    int Scenenumber;
    // Start is called before the first frame update
    void Start()
    {


        Scenenumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        win = true;
        for (int i = 0; i < d.Length; i++)
        {
           
            if (cd[i] != d[i].a)
            {
                win = false;
            }
        }

        if (win == true)
        {
            gameclaer = true;
            Invoke("Scenemove", 0.2f);
            SceneManager.LoadScene(Scenenumber + 1);
        }
    }
}


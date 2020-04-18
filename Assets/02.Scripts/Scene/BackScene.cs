using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackScene : MonoBehaviour
{


    int Scenenumber;
    // Start is called before the first frame update
    void Start()
    {
        Scenenumber = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame

    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos")
        {
            SceneManager.LoadScene(Scenenumber - 1);
            


        }
    }
}





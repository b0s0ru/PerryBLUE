using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorSensing : MonoBehaviour
{
    // Start is called before the first frame update
    int Scenenumber;
    void Start()
    {


        Scenenumber = SceneManager.GetActiveScene().buildIndex;
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Mpos")
        {

            SceneManager.LoadScene(Scenenumber + 1);
        }
    }
}

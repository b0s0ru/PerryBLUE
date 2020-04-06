using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos")
        {

            gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }
    }
}

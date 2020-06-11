using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensing : MonoBehaviour
{
    // Start is called before the first frame update


    void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.gameObject.tag == "Mpos")
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {



        if (other.gameObject.tag == "Mpos")
        {

            if (Player.instance.Hp>0)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            }

    }

}

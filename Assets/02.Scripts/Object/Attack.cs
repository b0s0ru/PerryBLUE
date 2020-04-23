using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    // Start is called before the first frame update
    public int Deal;
   
    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos")
        {
            GetComponent<Rigidbody2D>().WakeUp();
            collision.gameObject.SendMessageUpwards("SetDamage",Deal);
           
        }
    }

}
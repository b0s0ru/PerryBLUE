using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArm : MonoBehaviour
{
    Boss a;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.transform.parent.GetComponent<Boss>();
    }

    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos")
        {
            a.GetComponent<Rigidbody2D>().WakeUp();

            collision.gameObject.SendMessageUpwards("SetDamage", a.Damage);

        }
    }

}
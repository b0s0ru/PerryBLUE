using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    Monster a;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.GetComponent<Monster>();
    }

    void OnTriggerStay2D(Collider2D collision)

    {
       

        if (collision.transform.tag == "Mpos" && a.state != Monster.MonsterState.Die)
        {
            
            collision.gameObject.SendMessageUpwards("SetDamage", a.Damage);

        }
    }

}
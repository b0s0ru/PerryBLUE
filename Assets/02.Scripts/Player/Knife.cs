using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Wait)
        {
            state = PlayerState.Attack;
            anim.SetTrigger("Attacking");
            StartCoroutine(Attackis());


        }
    }

    IEnumerator Attackis()
    {
        yield return new WaitForSeconds(0.1f);
        if (state == PlayerState.Attack)
        {
            Kchild.kp.enabled = true;
            StartCoroutine(PWaitForIt());
        }


    }
    IEnumerator PWaitForIt()
    {
        yield return new WaitForSeconds(0.15f);
        if (state == PlayerState.Attack)
        {
            state = PlayerState.Wait;
            if (Kchild.kp.enabled == true)
            {
                Kchild.kp.enabled = false;
            }
        }
        else if (Kchild.kp.enabled == true)
        {
            Kchild.kp.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    Monster a;
    Move b;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.GetComponent<Monster>();
        b = gameObject.transform.parent.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D collision)

    {

        if (a.state != Monster.MonsterState.Die)
        {
            if (collision.gameObject.layer == 8)
            {

                if (b.movementFlag == 1)
                {
                    b.movementFlag = 2;
                    StartCoroutine("StopRoutie");
                }
                else if (b.movementFlag == 2)
                {
                    b.movementFlag = 1;
                    StartCoroutine("StopRoutie");
                }
            }
        }
    }

    IEnumerator StopRoutie()
    {
        b.StopCoroutine("ChangeMovement");
        yield return new WaitForSeconds(1.5f);
        b.StartCoroutine("ChangeMovement");
    }
}

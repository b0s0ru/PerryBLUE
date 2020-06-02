using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
   
    Vector3 movement;

   public int movementFlag = 0;
    Monster mob;
    void Start()
    {
        mob = GetComponent<Monster>();
        
            StartCoroutine("ChangeMovement");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mob.state == Monster.MonsterState.Moves)
        {
            Moving();
        }
    }

    void Moving()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * mob.speed * Time.deltaTime;
        
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(1, 3);

        yield return new WaitForSeconds(2f);

        StartCoroutine("ChangeMovement");
    }
}

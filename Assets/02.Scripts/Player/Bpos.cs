using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bpos : MonoBehaviour
{
    // Start is called before the first frame update
    Player a;
    private void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
        {

            a.isGround = true;
            if (a.state == Player.PlayerState.Fall)
            {
                a.anim.SetTrigger("Land");
            }
            a.state = Player.PlayerState.Wait;
           
            // a.anim.SetBool("isground", true);
            a.moveDir.y = 0;
          //  a.anim.SetBool("Jumping", false);
        

        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
    

            if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
            {
                a.isGround = false;
          //      a.anim.SetTrigger("Fall");
            //    a.anim.SetBool("isground", false);

            }
        
    }
}

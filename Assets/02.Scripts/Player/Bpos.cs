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
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
        {
            a.anim.SetBool("isground", true);
            a.isGround = true;

        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10 && a.state!=Player.PlayerState.die && (a.state==Player.PlayerState.JumpFall|| a.state == Player.PlayerState.RunFall))
        {
            
          
           // a.anim.SetBool("isground", true);
            
            a.moveDir.x = 0;
            a.anim.SetTrigger("Land");
          

            StartCoroutine("Landai");
         
           

            // a.anim.SetBool("isground", true);

            //  a.anim.SetBool("Jumping", false);


        }


    }
    IEnumerator Landai()
    {
        a.moveDir.y = 0;
        a.transform.Translate(new Vector3(0, -0.13f, 0));
        a.Mpos.SetActive(false);
        yield return new WaitForSeconds(0.15f); 
        a.state = Player.PlayerState.Wait;
       
        a.transform.Translate(new Vector3(0, +0.13f, 0));
        a.moveDir.y = 0;0
        a.Mpos.SetActive(true);

    }
    void OnTriggerExit2D(Collider2D other)
    {
    

            if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
            {
                a.isGround = false;
            a.anim.SetBool("isground", false);
            if (a.state == Player.PlayerState.Wait)
            {
                a.state = Player.PlayerState.RunFall;
            }

            //   a.anim.SetTrigger("Fall");
            //    a.anim.SetBool("isground", false);

        }
        
    }
}

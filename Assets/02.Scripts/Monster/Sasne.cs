using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sasne : MonoBehaviour
{
    Monster mob;
   
  
    // Start is called before the first frame update
    void Start()
    {
        mob = gameObject.transform.parent.GetComponent<Monster>();
        
    }

    // Update is called once per frame
  
    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos" && mob.state == Monster.MonsterState.Moves)
        {

            mob.state = Monster.MonsterState.Tracks;
            mob.anim.SetTrigger("Sanse");

        }
       
    }
    void OnTriggerExit2D(Collider2D collision)
{

    if (collision.transform.tag == "Mpos" && mob.state ==Monster.MonsterState.Tracks)
    {

        mob.state = Monster.MonsterState.Moves;
            mob.anim.SetTrigger("Back");

        }
}
}   


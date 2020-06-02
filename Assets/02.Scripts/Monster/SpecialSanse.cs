using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSanse : Sasne
{


    public bool Check;
    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
       
    }

    void OnTriggerStay2D(Collider2D collision)

    {
        

        if (collision.transform.tag == "Mpos" && mob.state == Monster.MonsterState.Moves)
        {
           
            mob.state = Monster.MonsterState.Tracks;
            mob.anim.SetTrigger("Sanse");
            
        }
        if(collision.transform.tag == "Mpos" && Check==false)
        {
            Check = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.transform.tag == "Mpos" && mob.state!=Monster.MonsterState.Die && mob.state != Monster.MonsterState.Moves)
        {
            Check = false;
     

        }
    }
}


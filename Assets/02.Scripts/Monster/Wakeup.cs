using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakeup : MonoBehaviour
{
    Monster mob;
    bool s = false;
    // Start is called before the first frame update
    void Start()
    {
        mob = gameObject.transform.parent.GetComponent<Monster>();
        

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos" && mob.state == Monster.MonsterState.Wait)
        {
            StartCoroutine("start");
            s = true;
            
          

        }

    }
    IEnumerator start()
    {
        
        mob.anim.SetTrigger("Wakeup");
        yield return new WaitForSeconds(0.8f);
        
        mob.state = Monster.MonsterState.Tracks;
    }
}

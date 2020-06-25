using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBossAttack : MonoBehaviour
{
    Boss mob;
    Vector3 playerPos;
    Vector2 dir;
    Vector3 moveVelocity = Vector3.zero;
    Animator anim;
    GameObject MonsterBullet;
    public Transform firePos;
    bool bulletis;
    GameObject ins;
    public float delay;
    public string s;
    // Start is called before the first frame update
    void Start()
    {
        mob = transform.parent.GetComponent<Boss>();
        // anim = GetComponent<Animator>();
        MonsterBullet = Resources.Load(s, typeof(GameObject)) as GameObject;
        bulletis = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mob.state == Boss.MonsterState.Wait2&& bulletis==true)
        {
            bulletis = false;
            StartCoroutine("Monsteratack");
            

        }
        if (mob.state == Boss.MonsterState.Attack2&& bulletis==false)
        {
            bulletis = true;
        }

        /*     if (mob.state == Monster.MonsterState.Tracks)
             {


                 //anim.SetBool("Atacking", true);

                 if (bulletis == true)
                 {
                     bulletis = false;
                     StartCoroutine("Delays");
                 }

             }
             else if (mob.state == Monster.MonsterState.Moves && !bulletis)
             {
                 StopCoroutine("Monsteratack");
                 StopCoroutine("Delays");
                 bulletis = true;
             }
             else if (mob.state == Monster.MonsterState.Damage)
             {
                 StopCoroutine("Monsteratack");
                 StopCoroutine("Delays");
                 bulletis = true;
             }
             */
    }
    /*IEnumerator Delays()
     {

         yield return new WaitForSeconds(1.5f);

         StartCoroutine("Monsteratack");
     }*/
    IEnumerator Monsteratack()
    {
        /* if (mob.state == Monster.MonsterState.Tracks)
          {

        
      */
        
        int random = Random.Range(1, 101);
        if (random < 75)
        {
            ins = Instantiate(MonsterBullet, firePos.position, firePos.rotation);

            
        }
        yield return new WaitForSeconds(delay);
        if (mob.state == Boss.MonsterState.Wait2)
        {
            StartCoroutine("Monsteratack");
        }
       
        /*}

        }*/

    }
   
}

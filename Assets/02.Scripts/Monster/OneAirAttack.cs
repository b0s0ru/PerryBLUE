using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneAirAttack : MonoBehaviour
{
    Monster mob;
    Vector3 playerPos;
    Vector2 dir;
    Vector3 moveVelocity = Vector3.zero;
    Animator anim;
    GameObject MonsterBullet;
    public Transform firePos;
    bool bulletis = true;
    GameObject ins;
    public float delay;
    public string s;

    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Monster>();
        anim = GetComponent<Animator>();
        MonsterBullet = Resources.Load(s, typeof(GameObject)) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Monster.target == null || Monster.target.Equals(null)) return;
        playerPos = Monster.target.transform.position;



        if (mob.state == Monster.MonsterState.Tracks)
        {


          
            if (bulletis == true)
            {
                bulletis = false;
                StartCoroutine("Delays");
            }

        }
        if (mob.state == Monster.MonsterState.Damage)
        {
            StopCoroutine("Monsteratack");
            StopCoroutine("Delays");
            bulletis = true;
            
        }


    }
    IEnumerator Delays()
    {

        yield return new WaitForSeconds(4.5f);
        StartCoroutine("Monsteratack");
    }
    IEnumerator Monsteratack()
    {
        mob.state = Monster.MonsterState.Attacks;
            anim.SetTrigger("ready");
             yield return new WaitForSeconds(delay);
            
            ins = Instantiate(MonsterBullet, firePos.position, firePos.rotation);

            yield return new WaitForSeconds(delay);
            ins = Instantiate(MonsterBullet, firePos.position, firePos.rotation);

            yield return new WaitForSeconds(delay);
            ins = Instantiate(MonsterBullet, firePos.position, firePos.rotation);

            yield return new WaitForSeconds(delay);
            bulletis = false;
            StartCoroutine("Delays");

        mob.state = Monster.MonsterState.Tracks;

    }

  
}

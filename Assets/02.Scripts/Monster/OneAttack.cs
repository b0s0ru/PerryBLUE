using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneAttack : MonoBehaviour
{
    Monster mob;
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
        mob = GetComponent<Monster>();
        anim = GetComponent<Animator>();
        MonsterBullet = Resources.Load(s, typeof(GameObject)) as GameObject;
        bulletis = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Monster.target == null || Monster.target.Equals(null)) return;
        playerPos = Monster.target.transform.position;



        if (mob.state == Monster.MonsterState.Tracks)
        {


            //anim.SetBool("Atacking", true);
            Atacks();
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
      
    }
    IEnumerator Delays()
    {

        yield return new WaitForSeconds(1.5f);
        
        StartCoroutine("Monsteratack");
    }
    IEnumerator Monsteratack()
    {
        if (mob.state == Monster.MonsterState.Tracks)
        {


            ins = Instantiate(MonsterBullet, firePos.position, firePos.rotation);

            yield return new WaitForSeconds(delay);
         
            StartCoroutine("Monsteratack");
        }
       
    }

    void Atacks()
    {
        dir = playerPos- transform.position;
        if (dir.x < 0)
        {

            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {

            transform.localScale = new Vector3(-1, 1, 1);

        }


    }
}

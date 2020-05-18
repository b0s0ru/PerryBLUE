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
    bool bulletis = true;
    GameObject ins;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Monster>();
        anim = GetComponent<Animator>();
        MonsterBullet = Resources.Load("Bullet", typeof(GameObject)) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Monster.target == null) return;
        playerPos = Monster.target.transform.position;
        
       
       
        if (mob.state == Monster.MonsterState.Tracks)
        {
            
            
            //anim.SetBool("Atacking", true);
            Atacks();
            if (bulletis == true)
            {
                bulletis = false;
                StartCoroutine("Monsteratack");
            }
        }
      
    }

    IEnumerator Monsteratack()
    {
       
      
         ins = Instantiate(MonsterBullet, firePos.position, firePos.rotation);
        
        yield return new WaitForSeconds(delay);
        bulletis = true;

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

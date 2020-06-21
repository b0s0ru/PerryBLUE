using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushing : MonoBehaviour
{
    Monster mob;
    Vector3 playerPos;
    Vector2 dir;
    
    Animator anim;
    GameObject MonsterBullet;
   
    Vector3 moveVelocity = Vector3.zero;
    GameObject ins;
    public float delay;
    public string s;
    public bool rushs;
    SpecialSanse d;
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Monster>();
        anim = GetComponent<Animator>();
        d = transform.Find("scene").GetComponent<SpecialSanse>();
        MonsterBullet = Resources.Load(s, typeof(GameObject)) as GameObject;
        if (Monster.target == null) return;
        rushs = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        

        if (rushs == false &&mob.state== Monster.MonsterState.Tracks)
        {   
            transform.position += moveVelocity *6 * Time.deltaTime;
        }
        if (mob.state == Monster.MonsterState.Tracks && rushs == true)
        {

            
            rushs = false;
            StartCoroutine("Rush");

        }
       

       
        
    }
    
    IEnumerator Repir()
    {
        rushs = true;
        yield return new WaitForSeconds(3f);
        
        if (mob.state ==Monster.MonsterState.human && d.Check)
        {
            mob.anim.SetTrigger("repair");
            mob.state = Monster.MonsterState.Tracks;
        }
        else if (d.Check == false)
        {
            mob.state = Monster.MonsterState.Moves;
            mob.anim.SetTrigger("Back");
        }
    }
    IEnumerator Rush()
    {
        
        playerPos = Monster.target.transform.position;

        moveVelocity = Vector3.zero;
        if (playerPos.x - transform.position.x >= 0){
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
            Debug.Log(playerPos.x - transform.position.x);
        }
        else
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
            Debug.Log(playerPos.x - transform.position.x);
        }
        yield return new WaitForSeconds(3f);
        mob.state = Monster.MonsterState.human;
        mob.anim.SetTrigger("rush");
        StartCoroutine("Repir");
    }
   

  
}

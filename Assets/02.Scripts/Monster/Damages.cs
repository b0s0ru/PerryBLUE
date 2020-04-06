using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Monster my;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        my = GetComponent<Monster>();
    }
    void MobDamage(int mDamage)
    {
        if (my.state != Monster.MonsterState.Die)
        {
               
           
            my.Hp -= mDamage;
            if (my.Hp < 0)
            {
                my.Hp = 0;
            }
            if (my.Hp>0)
            {
               
                my.anim.SetTrigger("Damage");
                StopCoroutine("Hit");
                StartCoroutine("Hit");
            }   

        }
    }
    IEnumerator Hit()
    {   
        my.state = Monster.MonsterState.Damage;
        //  spriteRenderer.color = new Color32(0, 255, 255, 255);
        yield return new WaitForSeconds(1.5f);
        // spriteRenderer.color = new Color(255, 255, 255, 255);
        if (my.state != Monster.MonsterState.Die)
        {
            my.state = Monster.MonsterState.Moves;
        }
    }
}

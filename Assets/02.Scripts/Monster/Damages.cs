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
            StartCoroutine("Hit");
            my.state = Monster.MonsterState.Damage;
        }
    }
    IEnumerator Hit()
    {


        spriteRenderer.color = new Color32(0, 255, 255, 255);
        yield return new WaitForSeconds(0.8f);
        spriteRenderer.color = new Color(255, 255, 255, 255);
        my.state = Monster.MonsterState.Tracks;

    }
}

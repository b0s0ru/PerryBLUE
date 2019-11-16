using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Monster my;
  
    // Start is called before the first frame update
    void Start()
    {
      my = GetComponent<Monster>();

    }

    // Update is called once per frame
    void Update()
    {   
        if (my.Hp <= 0 && my.state != Monster.MonsterState.Die)
        {
            Dead();
            
        }
    }

    void Dead()
    {
       
        my.state = Monster.MonsterState.Die;
        my.anim.SetTrigger("Die");
        StartCoroutine(Dies());
    }

    IEnumerator Dies()
    {
        


        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}

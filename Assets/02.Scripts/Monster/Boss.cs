using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character
{
    // Start is called before the first frame update
    public enum MonsterState
    {
        Wait = 0, Wait1, Wait2, Attack, Attack2
    }
    public MonsterState state;
    int a;
    int b;
  
    public Animator anim;
    void Start()
    {
        Hp = 200;
        Damage = 20;
        state = MonsterState.Wait;
        anim = GetComponent<Animator>();
       
    }
    private void FixedUpdate()
    {
        if (state == MonsterState.Wait)
        {
           
            StartCoroutine("Change");
            state = MonsterState.Wait2;

        }
        if (state == MonsterState.Attack)
        {
            state = MonsterState.Attack2;
             a= Random.Range(0, 8);
            b= Random.Range(0,7);

            if (a <= b)
            {
                b++;
            }
            for (int i = 0; i <= 7; i++)
            {
                if (i != a && i != b)
                {
                    transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.red;
                   
                }
                else
                {
                    transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.blue;
                    
                }

            }
            Invoke("AttackDelay", 3.5f);
          
            
        }// Update is called once per frame
    }
    void AttackDelay()
    {
        for (int i = 0; i <= 7; i++)
        {
            if (i != a && i != b)
            {
                
                transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                
                transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(true);
            }

        }

        Invoke("Delay", 0.8f);
    }
    void Delay()
    {
        for (int i = 0; i <= 7; i++)
        {
            if (i != a && i != b)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                
                transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(true);
            }


        }
        Invoke("DamagesON", 1.6f);
    }
    void DamagesON()
    {
        for (int i = 0; i <= 7; i++)
        {
            if (i == a || i == b)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(false);
               
            }
           
        }
        state = MonsterState.Wait;
    }
        IEnumerator Change()
    {
        yield return new WaitForSeconds(7f);
        state = MonsterState.Attack;
    }
}

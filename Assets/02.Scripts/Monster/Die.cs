using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Monster my;
    int playerhp = 0;
    public static Player players;
    // Start is called before the first frame update
    private void Awake()
    {
        players = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
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
        if (players.state != Player.PlayerState.die)
        {
            playerhp = players.Hp;
        }


    }

    void Dead()
    {
       
        my.state = Monster.MonsterState.Die;
        Debug.Log("ie");
        my.anim.SetTrigger("Die");
        StartCoroutine(Dies());
    }

    IEnumerator Dies()
    {

        players.SendMessageUpwards("killmob", my.plushp);

        yield return new WaitForSeconds(1f);
       
        Destroy(gameObject);

    }
}

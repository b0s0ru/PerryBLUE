using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Monster my;
    bool whodie;
    public static Player players;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        whodie = true;
        my = GetComponent<Monster>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Dead();



    }

    void Dead()
    {
        if (my.Hp == 0 && whodie)
        {
            whodie = false;
            my.state = Monster.MonsterState.Die;
            Deads();

        }     
        
    }

    void Deads()
    {
        GameObject.Find("Player").GetComponent<Player>().Killmob(10);
        my.anim.SetTrigger("Die");
        StartCoroutine(Dies());
      

    }
    IEnumerator Dies()
    {
        
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

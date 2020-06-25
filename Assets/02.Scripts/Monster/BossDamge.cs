using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamge : MonoBehaviour
{

   
    public Boss my;
    public Rigidbody2D ss;
    bool s;
    public ParticleSystem mobdamage;
    // Start is called before the first frame update
    private void Start()
    {
        
        my = transform.parent.transform.parent.GetComponent<Boss>();
        ss = transform.parent.transform.parent.GetComponent<Rigidbody2D>();
        s = false;
    }
    void MobDamage(int mDamage)
    {
        mobdamage.Play();
        
     
        ss.WakeUp();
        my.Hp -= mDamage;
            if (my.Hp <= 0)
            {
                my.Hp = 0;
                Destroy(transform.parent.transform.parent.gameObject);
        }   
            if (my.Hp > 0)
            {
                ss.WakeUp();
           
            }

        
    }
    
}

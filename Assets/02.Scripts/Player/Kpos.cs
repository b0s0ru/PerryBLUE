﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kpos : MonoBehaviour
{
    public Collider2D kp;
    

    private void Start()
    {
        kp = GetComponent<Collider2D>();
       
        kp.enabled = false;
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {

       
        if (other.transform.tag == "Monster")
        {
           
           
            var sm = SoundManager.Instance;
            sm.PlaySFX("Hit");
            other.gameObject.SendMessageUpwards("MobDamage", 10);
                
            kp.enabled = false;
        }
        if (other.transform.tag == "Destroy")
        {
            other.gameObject.SendMessage("Destroy");
        }
    
    }
}

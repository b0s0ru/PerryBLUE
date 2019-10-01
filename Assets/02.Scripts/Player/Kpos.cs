using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kpos : MonoBehaviour
{
    public Collider2D kp;
    AudioSource hits;

    private void Start()
    {
        kp = GetComponent<Collider2D>();
        hits = GetComponent<AudioSource>();
        kp.enabled = false;
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {

       
        if (other.transform.tag == "Monster")
        {
            Debug.Log("Mosterhit");
            hits.Play();
            other.gameObject.SendMessage("MobDamage", 10);
            kp.enabled = false;
        }

    
    }
}

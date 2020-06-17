using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    static Player s;
    
    ParticleSystem r1;
   // ParticleSystem r2;

    private void Start()
    {
        s=GameObject.Find("Player").transform.GetComponent<Player>();
        r1 = GameObject.Find("FX_recover_01").GetComponent<ParticleSystem>();
       
       // r2 = recovery.transform.GetChild(1).GetComponent<ParticleSystem>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mpos" && Input.GetKeyDown(KeyCode.UpArrow))
        {

            Saves();
        }

    }

    public void Saves()
    {
        r1.Play();
        //r2.Play();
        s.Full();
        PlayerPrefs.SetInt("map", s.index);
        PlayerPrefs.SetString("keys", gameObject.name);
        for (int i = 1; i <=s.max; i++)
        {
           
            PlayerPrefs.SetInt("texts" + i, s.Read[i] ? 1 : 0);
        }
        
        PlayerPrefs.Save();
    }

}



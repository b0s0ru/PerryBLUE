using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    static Player s;
    ParticleSystem recovery;

    private void Start()
    {
        s=GameObject.Find("Player").transform.GetComponent<Player>();
        recovery = GameObject.Find("parline1_add").transform.GetComponent<ParticleSystem>();
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
        recovery.Play();
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



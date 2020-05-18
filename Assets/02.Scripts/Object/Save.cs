using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    static Player s;

    private void Start()
    {
        s=GameObject.Find("Player").transform.GetComponent<Player>();
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
        s.full();
        PlayerPrefs.SetInt("map", s.index);
        for (int i = 1; i <=s.max; i++)
        {
           
            PlayerPrefs.SetInt("texts" + i, s.Read[i] ? 1 : 0);
        }
        
        PlayerPrefs.Save();
    }
}



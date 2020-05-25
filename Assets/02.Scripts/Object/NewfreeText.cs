using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewfreeText : MonoBehaviour
{
    // Start is called before the first frame update

    public int n;

    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        var singleton = Texts.Instance;


        if (other.gameObject.tag == "Mpos")
        {
            Player a = other.gameObject.transform.parent.GetComponent<Player>();
           
             singleton.TextOn(n.ToString());
            
           
        }

    }

    private void OnLevelWasLoaded(int level)
    {

    }
}


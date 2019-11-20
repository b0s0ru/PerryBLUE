using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensing : MonoBehaviour
{
    // Start is called before the first frame update
    int a;
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log(gameObject);
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<Player>().pnife = true;
    }

    // Update is called once per frame
  

    
}

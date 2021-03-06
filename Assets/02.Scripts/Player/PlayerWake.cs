﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWake : MonoBehaviour
{
    SpriteRenderer s;
    Player a;
    GameObject c;
    // Start is called before the first frame update
    void Start()
    {
        s = Player.instance.GetComponent<SpriteRenderer>();
        s.color = new Color(255, 255, 255, 0);
        a = Player.instance.GetComponent<Player>();
        StartCoroutine("Wake");
        c = GameObject.Find("Canvas").transform.Find("HPbar").gameObject;
        c.SetActive(false);
    }
    private void FixedUpdate()
    {
        a.stop = true;
    }

    // Update is called once per frame
    IEnumerator Wake()
    {
       
        yield return new WaitForSeconds(5.51f);
        
        Destroy(gameObject);
        s.color = new Color(255, 255, 255, 255);
        Player.instance.GetComponent<Player>().stop = false;
        c.SetActive(true);
       
    }
}

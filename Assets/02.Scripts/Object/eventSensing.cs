﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSensing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {
            GameObject.Find("GameObject").transform.Find("cabinet_in").gameObject.SetActive(true);
            Destroy(gameObject);
            GameObject.Find("Canvas/GameObject").transform.Find("1_manual").gameObject.SetActive(true);
            GameObject.Find("GameObject/door").gameObject.GetComponent<clear>().d[5] = true;

        }

    }
}

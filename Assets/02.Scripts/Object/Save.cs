﻿using System.Collections;
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
        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {

            Saves();
        }

    }

    public void Saves()
    {
        s.full();
        PlayerPrefs.SetInt("map", s.index);
        PlayerPrefs.Save();
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOn : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {
            


        }

    }
}

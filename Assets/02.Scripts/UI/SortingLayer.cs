using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer sprite;
    void Awake()
    {
        sprite = GetComponent<MeshRenderer>();
        sprite.sortingOrder =4;
    }

    // Update is called once per frame
    
}

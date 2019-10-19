using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBlock : MonoBehaviour
{

    public bool blockclocking = false;
    int child;
    public float a;
    bool one = true;
    BoxCollider2D m_collider;
    // Start is called before the first frame update


     void Start()
    {
        child= transform.childCount;
        m_collider = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.transform.tag=="BPos")
        {

            if (one)
            {
                one = false;
                StartCoroutine("Clockchange");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  
    IEnumerator Clockchange()
    {


        yield return new WaitForSeconds(a);
        blockclocking = !blockclocking;
        if (blockclocking)
        {
            for (int i = 0; i < child; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                m_collider.enabled = false;
            }

        }
        else
        {
            
                for (int i = 0; i < child; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                m_collider.enabled = true;
            }

            
        }
        StartCoroutine("Clockchange");
    }
}

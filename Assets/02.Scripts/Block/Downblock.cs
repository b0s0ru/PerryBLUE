using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downblock : MonoBehaviour
{
    
    public float a;
    bool one = true;
    bool fall = true;
    float movePower = 1f;
    float movespeed = 20;
    BoxCollider2D m_collider;
    public void Start()
    {
        m_collider = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.transform.tag == "BPos")
        {

            if (one)
            {
                one = false;
                StartCoroutine("Downblocks");
            }
        }
        if ( other.gameObject.layer==8 &&fall == false)
        {
            fall = true;
            m_collider.isTrigger = false;
        }
    
    }
    private void Update()
    {
        if (!fall)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        moveVelocity = new Vector3(0, -movePower, 0);

        transform.position += moveVelocity * movespeed * Time.deltaTime;
    }
    IEnumerator Downblocks()
    {


        yield return new WaitForSeconds(a);
        m_collider.isTrigger = true;
        fall = false;
      

    }
}

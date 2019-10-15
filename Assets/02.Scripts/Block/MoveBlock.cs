using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{

    public bool blockmove = false;
    public float movespeed = 20;
    float movePower = 0.12f;
    public float a;
   
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine("Blockchange");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


   void Move() {
       Vector3 moveVelocity = Vector3.zero;
        if (blockmove == false)
        {
            moveVelocity = new Vector3(movePower, 0, 0);
        }
        else
        {
            moveVelocity = new Vector3(-movePower, 0, 0);
        }
      
        transform.position += moveVelocity * movespeed * Time.deltaTime;
    }
    IEnumerator Blockchange() {
        
        
        yield return new WaitForSeconds(a);
        blockmove = !blockmove;
        StartCoroutine("Blockchange");
    }
}

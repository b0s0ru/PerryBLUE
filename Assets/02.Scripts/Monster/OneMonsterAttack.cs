using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMonsterAttack : MonoBehaviour
{

    public float Damage;

    Transform c;
    Vector2 dir;

    // Start is called before the first frame update
    void Awake()
    {
      //  Destroy(this.gameObject, 3);
      c=Monster.target.GetComponent<Transform>();
        dir = c.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * 5000);
        
    }
    private void Start()
    {

        Destroy(gameObject, 10f);
    }
    private void Update()
    {
     

   
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Mpos")
        {
            Debug.Log("s");
            collision.gameObject.SendMessageUpwards("SetDamage", Damage);
           
            Destroy(gameObject);
        }
    }
}
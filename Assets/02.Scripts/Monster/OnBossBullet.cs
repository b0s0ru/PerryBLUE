using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Damage;

    Transform c;
    Vector2 dir;

    // Start is called before the first frame update
    void Awake()
    {
        //  Destroy(this.gameObject, 3);
        //c = Monster.target.GetComponent<Transform>();
        int ax = Random.Range(-100, 100);
        int ay = Random.Range(-100, 100);

        dir.x = ax;
        dir.y = ay;
        dir.Normalize();
      
        GetComponent<Rigidbody2D>().AddForce(dir * 450);

    }
    private void Start()
    {

        Destroy(gameObject, 2.5f);
    }
    private void Update()
    {



    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.tag == "Mpos")
        {

            collision.gameObject.SendMessageUpwards("SetDamage", Damage);

            Destroy(gameObject);
        }
    }
}

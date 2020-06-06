using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    Monster mob;
    Vector3 dir;
    void Start()
    {
        target = Player.instance.transform;
        mob = GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mob.state == Monster.MonsterState.Tracks&& target!=null)
        {
            dir = (target.position - transform.position);
            dir.y += 1.2f;
            dir.Normalize();
            transform.position += dir * mob.speed * Time.deltaTime;
        }
      
    }
}

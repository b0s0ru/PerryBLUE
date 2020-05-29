
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loming : Monster
{
   

    // Start is called before the first frame update
    void Start()
    {
        Hp = 20;
        Damage = 10;
        speed = 2;
        plushp = 10;
        state = MonsterState.Moves;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : Monster
{


    // Start is called before the first frame update
    void Start()
    {
        Hp = 60;
        Damage = 20;
        //speed = 2;
        plushp = 20;
        state = MonsterState.Moves;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rush : Monster
{


    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        Damage = 30;
        speed = 1.5f;
        plushp = 30;
        state = MonsterState.Moves;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }


}

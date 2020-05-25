using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        Damage = 20;
        speed = 2.5f;
        plushp = 20;
        state = MonsterState.Wait;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
}

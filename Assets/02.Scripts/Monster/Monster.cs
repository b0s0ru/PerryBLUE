using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public enum MonsterState
    {
        Wait = 0, Moves, Tracks, Die, Damage
    }

   public static Transform target;
    public MonsterState state;
    
    public Animator anim;
    // Start is called before the first frame update
    void Awake()
    {

        target =  GameObject.FindWithTag("Player").GetComponent<Transform>();
        

    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   
  
    
}

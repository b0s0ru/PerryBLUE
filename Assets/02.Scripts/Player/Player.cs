using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     Rigidbody2D rbody;
    public int Hp;
    public float speed;
    public int Damage;
    public Animator anim;
    float keys;
    public float SpeedJump = 9;
    public PlayerState state = PlayerState.Wait;
    public bool isGround = false;
    float dir=1;
    public Vector2 moveDir;
    SpriteRenderer spriteRenderer;
    float gravity = 20;
    public enum PlayerState
    {
        Wait = 0, Jump, Fall
    }
    // Start is called before the first frame update
    void Start()
    {
        InitPlayer();
    }

    // Update is called once per frame
    void Update()
    {

        SetAnimation();

    }
    void FixedUpdate()
    {
        Playergravity();
        InputKey();
        JumpPlayer();
    }
    void Playergravity()
    {


        if (isGround == false)
        {
            moveDir.y -= gravity * Time.deltaTime;

        }
        if (moveDir.y < 0 && state == PlayerState.Jump)
        {
            
            state = PlayerState.Fall;
        }


        rbody.MovePosition(rbody.position + moveDir * Time.deltaTime);


    }

    void JumpPlayer()
    {

        if (isGround && Input.GetButton("Jump") && state == PlayerState.Wait )
        {
           
            moveDir.y = SpeedJump;
            state = PlayerState.Jump;
            anim.SetTrigger("Jumping");
        }


    }
    void SetAnimation()
    {

        anim.SetFloat("speed", Mathf.Abs(moveDir.x));
    }
    void InputKey()
    {
       
            keys = Input.GetAxis("Horizontal");
            moveDir.x = speed * keys;
            FlipPlayer(keys);


        


    }
    void FlipPlayer(float key)
    {
        if (key == 0) return;
        dir = (key > 0) ? -1 : 1;

        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }

    void InitPlayer()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        speed = 3.5f;
        Hp = 100;
    }
}

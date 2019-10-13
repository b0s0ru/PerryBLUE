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
    public float SpeedJump;
    public PlayerState state = PlayerState.Wait;
    public bool isGround = false;
    float dir=1;
    public Vector2 moveDir;
    SpriteRenderer spriteRenderer;
    public Kpos Kchild;
    public GameObject Bpos;
    public GameObject Mpos;
    float gravity = 32;
    public bool knife = false;
    public enum PlayerState
    {
        Wait = 0, Jump, Fall, die, Attack, Sit
    }
    // Start is called before the first frame update
    void Awake()
    {
        InitPlayer();
    }

    // Update is called once per frame
    void Update()
    {

       
        DeadCheck();

    }

    void FixedUpdate()
    {
        if (state != PlayerState.die)
        {
            Attack();
            SetAnimation();
            Playergravity();
            InputKey();
            JumpPlayer();
            Down();
            if (knife != false) { Knifes(); }
        }
    }
    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Wait && knife == true)
        {
            state = PlayerState.Attack;
            anim.SetTrigger("Attacking");
            StartCoroutine(Attackis());


        }
    }

    private void Down()
    {

        if (Input.GetKey(KeyCode.DownArrow) && state == PlayerState.Wait)
        {
            anim.SetTrigger("sit");
            state = PlayerState.Sit;
            moveDir.x = 0;
            transform.Translate(new Vector3(0, -0.45f, 0));
           Mpos.SetActive(false);
          
        }


        if (Input.GetKey(KeyCode.DownArrow) == false && state == PlayerState.Sit)
        {
            anim.SetTrigger("Up");
            state = PlayerState.Wait;
            transform.Translate(new Vector3(0, +0.45f, 0));
            Mpos.SetActive(true);
        }



    }
    void Knifes()
    {
        if (knife == true) {
            anim.SetBool("Knife", true);
        }
    }
    void DeadCheck()
    {

        if(Hp == 0 && state != PlayerState.die){
            Die();
            state = PlayerState.die;
            Bpos.SetActive(false);
            Mpos.SetActive(false);
        }
        
    }

    void Die()
    {
        anim.SetTrigger("Die");
        StartCoroutine(Dies());
    }
    IEnumerator Dies()
    {
        transform.Translate(new Vector3(0, -0.377f, 0));
        yield return new WaitForSeconds(1f);
        transform.Translate(new Vector3(0, -0.377f, 0));
        yield return new WaitForSeconds(0.254f);
        transform.Translate(new Vector3(0, -0.432f, 0));

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
           
            moveDir.y = SpeedJump + (Mathf.Abs(moveDir.x)*0.4f);
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
        if (state == PlayerState.Wait || state==PlayerState.Attack)
        {
            keys = Input.GetAxis("Horizontal");
            moveDir.x = speed * keys;
            FlipPlayer(keys);



        }

    }
    void FlipPlayer(float key)
    {
        if (key == 0) return;
        dir = (key > 0) ? -1 : 1;

        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }


    IEnumerator Attackis()
    {
        yield return new WaitForSeconds(0.1f);
        if (state == PlayerState.Attack)
        {
           Kchild.kp.enabled = true;
           StartCoroutine(PWaitForIt());
        }


    }
    IEnumerator PWaitForIt()
    {
        yield return new WaitForSeconds(0.15f);
        if (state == PlayerState.Attack)
        {
            state = PlayerState.Wait;
            if (Kchild.kp.enabled == true)
            {
                Kchild.kp.enabled = false;
            }
        }
        else if (Kchild.kp.enabled == true)
        {
            Kchild.kp.enabled = false;
        }
    }
    void InitPlayer()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Kchild =  transform.GetChild(2).GetComponent<Kpos>();
        Bpos = transform.GetChild(0).gameObject;
        Mpos = transform.GetChild(1).gameObject;
        speed = 4.5f;
        Hp = 100;
        SpeedJump = 9;
    }
}

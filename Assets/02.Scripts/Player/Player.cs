using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rbody;
    public int Hp;
    public float speed, Fspeed;
    public int Damage;
    public Animator anim;
    public float keys;
    public float SpeedJump;
    public PlayerState state = PlayerState.Wait;
    public bool isGround = false;
    float dir=1;
    public Vector2 moveDir;
    SpriteRenderer spriteRenderer;
    public Kpos Kchild;
    public GameObject Bpos;
    public GameObject Mpos;
    public GameObject SMpos;
    public GameObject Dpos;
    float gravity = 32;
    public bool moveblock = false;
    public bool pnife = false;
    public float mbs;
    public bool isUnBeatTime = false;
    public enum PlayerState
 
    {
        Wait = 0, Jump, JumpFall, die, Attack, Sit,RunFall,Falls, Damage
    }
  
    // Start is called before the first frame update
    void Awake()
    {
        InitPlayer();
    }

    // Update is called once per frame
    void Update()

    {
        if (state != PlayerState.die)
        {


            DeadCheck();
           
        }
    }

    void FixedUpdate()
    {
        if (state != PlayerState.die)
        {
            Attacks();
            InputKey();
            JumpPlayer();
            Down();

            SetAnimation();
          
            
           
        }
          Playergravity();
    }
   

    private void Down()
    {

        if (Input.GetKey(KeyCode.DownArrow) && state == PlayerState.Wait)
        {
            anim.SetTrigger("sit");
            state = PlayerState.Sit;
           // transform.Translate(new Vector3(0, -0.45f, 0));
          // Bpos.transform.Translate(new Vector3(0, +0.3f, 0));
            keys = 0;
         
           Mpos.SetActive(false);
            SMpos.SetActive(true);


        }
      

        if (Input.GetKey(KeyCode.DownArrow) == false && state == PlayerState.Sit)
        {
            anim.SetTrigger("Up");
            state = PlayerState.Wait;
         //   transform.Translate(new Vector3(0, +0.45f, 0));
         //   Bpos.transform.Translate(new Vector3(0, -0.3f, 0));
            Mpos.SetActive(true);
            SMpos.SetActive(false);
           
        }



    }
  
    void DeadCheck()
    {

        if(Hp == 0 && state != PlayerState.die){
            Die();
            state = PlayerState.die;
           Dpos.SetActive(true);
            Bpos.SetActive(false);
            Mpos.SetActive(false);
            SMpos.SetActive(false);
        }
               
    }

    void Die()
    {
        
      
      
        anim.SetTrigger("Die");
        Dpos.transform.Translate(new Vector3(0, +0.255f, 0));
      //  transform.Translate(new Vector3(0, -0.255f, 0));
      //  StartCoroutine(Dies());
    }
    IEnumerator Dies()
    {
        moveDir.x = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezePositionX;
       
      
        yield return new WaitForSeconds(3f);
        Dpos.transform.Translate(new Vector3(0, +0.455f, 0));
      //  transform.Translate(new Vector3(0, -0.455f, 0));
       
    }
    void Playergravity()
    {


        if (isGround == false && (state!=PlayerState.die &&state!=PlayerState.Sit))
        {
             
            moveDir.y -= gravity * Time.deltaTime;
            
        }
        if(state==PlayerState.die)
        {
            moveDir.y = -1;
        }
        if (moveDir.y < 0 && state ==PlayerState.Jump)
        {
            state = PlayerState.JumpFall;
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
        if (!moveblock)
        {
            anim.SetFloat("speed", Mathf.Abs(moveDir.x));
        }
        else
        {
            anim.SetFloat("speed", Mathf.Abs(moveDir.x - mbs) );
        }
        anim.SetFloat("fallspeed", moveDir.y);
    }
    void InputKey()
    {
        if (state == PlayerState.Sit)
        {
            if (!moveblock) { moveDir.x = 0; }
            else
            {
                moveDir.x = mbs;
            }
        }
        else if (moveblock &&(state != PlayerState.die && state != PlayerState.Damage))
        {
            keys = Input.GetAxis("Horizontal");
            FlipPlayer(keys);
            float s = speed * keys;
            float r = s + mbs;
            if (r > speed && r>0)
            {
                r = speed;
            }else if(r<speed*-1 && r < 0)
            {
                r = speed*-1;
            }
                moveDir.x = r;
           

        }
       else  if (state != PlayerState.die && state != PlayerState.Damage)
        {
            
                keys = Input.GetAxis("Horizontal");
                FlipPlayer(keys);
            
            moveDir.x = speed * keys;
          
            



        }


      
        
    }
    void Attacks()
    {

        if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Wait && pnife)
        {
            state = PlayerState.Attack;
            anim.SetTrigger("Attacking");
            StartCoroutine(Attackis());


        }
    }
    void SetDamage(int mDamage)
    {
        if (state != PlayerState.die)
        {
            if (!isUnBeatTime)
            {
                Hp -= mDamage;
               // state = PlayerState.Damage;
                isUnBeatTime = true;


                StartCoroutine("BeatTime");
                StartCoroutine("Hit");

            }
        }
    }
    IEnumerator Hit()
    {
        rbody.velocity = Vector2.zero;
        if (state == PlayerState.Sit)
        {
         //   transform.Translate(new Vector3(0, +0.45f, 0));
         //   Bpos.transform.Translate(new Vector3(0, -0.3f, 0));
            Mpos.SetActive(true);
            SMpos.SetActive(false);
        }
        state = PlayerState.Damage;

            moveDir.x = 0;
            moveDir.y = 0;
            anim.SetTrigger("Damage");
            //Vector2 attackedVelocity;
            // attackedVelocity = new Vector2(dir, 0.5f);
            // rbody.AddForce(attackedVelocity, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            // anim.SetBool("sit", false);
            
                state = PlayerState.Wait;
            
           
        
       // yield return new WaitForSeconds(0.5f);


    }
    IEnumerator BeatTime()
    {
        int count = 0;

        for (count = 0; count < 10; count++)
        {

            if (count % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);

            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.1f);


        }
        spriteRenderer.color = new Color(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
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
        }
        if (Kchild.kp.enabled == true)
        {
            Kchild.kp.enabled = false;
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


   
 
    void InitPlayer()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Kchild =  transform.GetChild(2).GetComponent<Kpos>();
        Bpos = transform.GetChild(0).gameObject;
        Mpos = transform.GetChild(1).gameObject;
        SMpos = transform.GetChild(5).gameObject;
        Dpos= transform.GetChild(6).gameObject;
        speed = 7.2f;
        Hp = 10;
        SpeedJump = 16.3f;
        
    }

    
}

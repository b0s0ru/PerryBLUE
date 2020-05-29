using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class Player : MonoBehaviour
{

    public Rigidbody2D rbody;
    public int Hp;
    public float speed, Fspeed;
    public int Damage;
    public  Animator anim;
    public float keys;
    public float SpeedJump;
    public PlayerState state = PlayerState.Wait;
    public bool isGround = false;
    float dir = 1;
    public Vector2 moveDir;
    SpriteRenderer spriteRenderer;
    public Kpos Kchild;
    public Kpos KUpchild;
    public Kpos KDownchild;
    public GameObject Bpos;
    public GameObject Mpos;
    public GameObject SMpos;
    public GameObject Dpos;
    public GameObject eyesight;
    float gravity = 32;
    AudioSource Runbgm;
    AudioSource Attackbgm;
    public bool moveblock = false;
    public bool pnife = false;
    public float mbs;
    public bool isUnBeatTime = false;
    public bool lands = false;
    public int Key = 0;
    public bool isperry = true;
    public bool ischange = false;
    public bool Finedustdamage = false;
    public bool stop = false;
    FadeController black;
    int map=0;
    GameObject whatswitch;
    public int index;
    public CinemachineVirtualCamera Vcamera;
    public bool[] Read;
    public int max = 300;
    public bool Startstop = false;
    
    public enum PlayerState

    {
        Wait = 0, Jump, JumpFall, die, Attack, Sit, Damage,JumpDamage,JumpAttack,See
    }
    public static Player instance;

    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
         DontDestroyOnLoad(this.gameObject);
        InitPlayer();
    }

    // Update is called once per frame
    void Update()

    {
        if (state != PlayerState.die)
        {
           

        }
    }

    void FixedUpdate()
    {
        if (state != PlayerState.die)
        {
            Attacks();
           
            InputKey();
            JumpPlayer();
            MultSee();
            DeadCheck();
            RunBgm();
            Down();
            SetAnimation();
           
        }
        Playergravity();

    }
   
    public void MultSee()
    {

        if (Input.GetKeyDown(KeyCode.C) && state == PlayerState.Wait && !isperry && stop == false && Startstop==false)
        {

            Vcamera.m_Lens.FieldOfView = 120;
            state=PlayerState.See;

        }
        else if (Input.GetKeyDown(KeyCode.C) && state == PlayerState.See && stop == false && Startstop == false)
        {
            
            Vcamera.m_Lens.FieldOfView = 90;
            state = PlayerState.Wait;

        }
    }
    
    /*
    public void exit(){

        stop = false;
       
    }*/
    public void Full()
    {
        Hp = 100;
    }
    public void Killmob(int plushp)
    {
        if (Hp + plushp > 100)
        {
            Hp = 100;
        }
        else
        {
            Hp += plushp;
        }
    }
    private void Down()
    {

        if (Input.GetKey(KeyCode.DownArrow) && state == PlayerState.Wait && stop==false &&Startstop == false)
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
            moveDir.x = 0;
            
        }
        if (Hp < 0)
        {
            Hp = 0;
        }
               
    }

    void Die()
    {


        
        anim.SetTrigger("Die");
      //  Dpos.transform.Translate(new Vector3(0, +0.255f, 0));
      //  transform.Translate(new Vector3(0, -0.255f, 0));
        StartCoroutine(Dies());
    }
    IEnumerator Dies()
    {

        //  rbody.constraints = RigidbodyConstraints2D.FreezePositionX;
       // Dpos.transform.Translate(new Vector3(0, +0.455f, 0));

        yield return new WaitForSeconds(5f);
        GameObject.Find("Canvas").transform.Find("UI_dead").gameObject.SetActive(true);
        GameObject.Destroy(gameObject);


    }

    
    void Playergravity()
    {
        if (stop == true ||Startstop == true)
        {
            moveDir.x = 0;
        }

        if (isGround == false && (state!=PlayerState.die &&state!=PlayerState.Sit &&state != PlayerState.See))
        {
             
            moveDir.y -= gravity * Time.deltaTime;
            
        }
        if(state==PlayerState.die)
        {
           
            moveDir.y -= gravity * Time.deltaTime;
        }
        if (moveDir.y < 0 && state ==PlayerState.Jump)
        {
            state = PlayerState.JumpFall;
        }
          
        

     
            rbody.MovePosition(rbody.position + moveDir * Time.deltaTime);
       

    }

    void JumpPlayer()
    {

        if (isGround && Input.GetButton("Jump") && state == PlayerState.Wait && stop == false && Startstop == false)
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
        if (stop == false && Hp >0 && Startstop == false) 
        {
            if (state == PlayerState.Sit || state== PlayerState.See)
            {
                if (!moveblock) { moveDir.x = 0; }
                else
                {
                    moveDir.x = mbs;
                }
                
            }
            else if (moveblock && (state != PlayerState.die && state != PlayerState.Damage && state!= PlayerState.JumpDamage))
            {
                keys = Input.GetAxis("Horizontal");
                FlipPlayer(keys);
                float s = speed * keys;
                float r = s + mbs;
                if (r > speed && r > 0)
                {
                    r = speed;
                }
                else if (r < speed * -1 && r < 0)
                {
                    r = speed * -1;
                }
                moveDir.x = r;
               

            }
            else if (state != PlayerState.die && state != PlayerState.Damage && state != PlayerState.JumpDamage)
            {

                keys = Input.GetAxis("Horizontal");
                FlipPlayer(keys);

                moveDir.x = speed * keys;
               




            }

          
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject.Find("Canvas").transform.Find("UI_menu").SendMessage("Esc");
            }


        }
    }

    public void Jenu(bool rsq, GameObject switchs)
    {
        
        if (stop == false && Startstop==false)
        {
            bool q = false;
            whatswitch = switchs;
            if (0 <= switchs.transform.position.x - transform.position.x && !rsq)
            {
                q = true;
            }
            else if (0 >= switchs.transform.position.x - transform.position.x && rsq)
            {
                q = true;
            }
         

            if (isperry == false && state == PlayerState.Wait && Input.GetKeyDown(KeyCode.Z) && q==true)
            {
                anim.SetTrigger("Button");
                StartCoroutine("JButton");
               
                if (rsq)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }
    void Attacks()
    {   
        if (stop == false && Startstop == false)
        {

            if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Wait && pnife && isperry == true)
            {
                state = PlayerState.Attack;
                anim.SetTrigger("Attacking");
                StartCoroutine(Attackis());
            }
            else if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.DownArrow) && (state == PlayerState.Jump || state == PlayerState.JumpFall) && pnife && isperry == true)
            {
                state = PlayerState.JumpAttack;
                Attackbgm.Play();
                anim.SetTrigger("DownAttacking");
                KDownchild.kp.enabled = true;
                StartCoroutine(DownAirAttackis());


            }
            else if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.UpArrow) && (state == PlayerState.Jump || state == PlayerState.JumpFall) && pnife && isperry == true)
            {
                state = PlayerState.JumpAttack;
                Attackbgm.Play();
                anim.SetTrigger("UpAttacking");
                KUpchild.kp.enabled = true;
                StartCoroutine(UpAirAttackis());
                if (moveDir.y > 0)
                {
                    moveDir.y = 0;
                }

            }
            else if (Input.GetKeyDown(KeyCode.Z) && (state == PlayerState.Jump || state == PlayerState.JumpFall) && pnife && isperry == true)
            {
                state = PlayerState.JumpAttack;
                Attackbgm.Play();
                anim.SetTrigger("Attacking");
                Kchild.kp.enabled = true;
                StartCoroutine(AirAttackis());


            }
        }

    }
    void SetDamage(int mDamage)
    {


        if (state != PlayerState.die&& stop==false && Startstop == false)
        {
           
            if (!isUnBeatTime)
            {
                Vcamera.m_Lens.FieldOfView = 90;
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
        if (state != PlayerState.Jump && state != PlayerState.JumpFall)
        {
            state = PlayerState.Damage;
        }
        else
        {
            state = PlayerState.JumpDamage;
        }

            moveDir.x = 0;
            moveDir.y = 0;
            anim.SetTrigger("Damage");
            //Vector2 attackedVelocity;
            // attackedVelocity = new Vector2(dir, 0.5f);
            // rbody.AddForce(attackedVelocity, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
        // anim.SetBool("sit", false);
        if (moveDir.y == 0)
        {
            state = PlayerState.Wait;
        }
        else
        {
            state = PlayerState.JumpFall;
        }
           
        
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
        
        Attackbgm.Play();
        yield return new WaitForSeconds(0.01f);
        if (state == PlayerState.Attack)
        {
            Kchild.kp.enabled = true;
            StartCoroutine(PWaitForIt());
        }

      
    }
    IEnumerator JButton()
    {
        moveDir.x = 0;
        stop = true;
        yield return new WaitForSeconds(1f);
        whatswitch.SendMessage("Change");
        yield return new WaitForSeconds(1f);
        stop = false;


    }
    IEnumerator AirAttackis()
    {
        yield return new WaitForSeconds(0.3f);
        if (state == PlayerState.JumpAttack)
        {
            state = PlayerState.JumpFall;
        }
        if (Kchild.kp.enabled == true)
        {
            Kchild.kp.enabled = false;
        }
        if (moveDir.y > 0)
        {
            moveDir.y = 0;
        }
    }
    IEnumerator UpAirAttackis()
    {
        yield return new WaitForSeconds(0.3f);
        if (state == PlayerState.JumpAttack)
        {
            state = PlayerState.JumpFall;
        }
        if (KUpchild.kp.enabled == true)
        {
            KUpchild.kp.enabled = false;
        }
        
        
    }
    IEnumerator DownAirAttackis()
    {
        yield return new WaitForSeconds(0.5f);
        if (state == PlayerState.JumpAttack)
        {
            state = PlayerState.JumpFall;
        }
        if (KDownchild.kp.enabled == true)
        {
            KDownchild.kp.enabled = false;
        }
        if (moveDir.y < 0)
        {
            moveDir.y = 3f;
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
        if (state != PlayerState.die)
        if (key == 0) return;
        
        dir = (key > 0) ? -1 : 1;

        Vector3 scale = transform.localScale;
      
        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
        
    }

    void RunBgm()
    {

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && lands == false && state == PlayerState.Wait && stop == false && Startstop == false)
        {

            lands = true;
            Invoke("SRunBgm", 0.3f);
        }

    }
    void SRunBgm()
    {
        if (state != PlayerState.die)
        {
            lands = false;

            Runbgm.Play();
        }
    }


    void InitPlayer()
    {

        Read = new bool[1000];
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Kchild =  transform.GetChild(2).GetComponent<Kpos>();
        Bpos = transform.GetChild(0).gameObject;
        Attackbgm = GetComponent<AudioSource>();
        Runbgm = Bpos.GetComponent<AudioSource>();
        Mpos = transform.GetChild(1).gameObject;
        SMpos = transform.GetChild(5).gameObject;
        Dpos= transform.GetChild(6).gameObject;
        KUpchild = transform.GetChild(8).GetComponent<Kpos>();
        KDownchild = transform.GetChild(9).GetComponent<Kpos>();
        speed = 7.2f;
        Hp = 100;
        Jumppower();
        eyesight = transform.GetChild(7).gameObject;
        eyesight.SetActive(true);
        Textsave();

    }
    void Textsave()
    {
        for (int i = 1; i <= max; i++)
        {
            if(PlayerPrefs.HasKey("texts" + i))
            {
               
                Read[i] = (PlayerPrefs.GetInt("texts" + i)!=0) ? true : false ;
                
            }
            else
            {
                PlayerPrefs.SetInt("texts" + i, 0);
            }

       
        }
        PlayerPrefs.Save();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode level)
    {
        black = GameObject.Find("Canvas").transform.Find("black").GetComponent<FadeController>();
        index = SceneManager.GetActiveScene().buildIndex;
        Vcamera = GameObject.Find("CM").GetComponent<CinemachineVirtualCamera>();
        MoveSetting(index);
        StartCoroutine("Black");
        
    }
    IEnumerator Black()
    {

        
       Startstop = true;
        moveDir.x = 0;
        moveDir.y = 0;
        yield return new WaitForSeconds(0.5f);
       
        black.FadeOut(0.5f);
        Startstop = false;

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Jumppower()
    {
        if (isperry)
        {
            SpeedJump = 16.3f * 1.2f;
        }
        else
        {
            SpeedJump = 16.3f;
        }
    }
    public void MoveSetting(int buildIndex)
    {

        if (map == 0 || map==24)
        {
            
            Vector2 xy = GameObject.Find("Load").transform.position;
            transform.position = xy;
            map = buildIndex;

        }
        else if (map < buildIndex)
        {
            Vector2 xy = GameObject.Find("Start").transform.position;
            transform.position = xy;
            map = buildIndex;
        }
        else if (map > buildIndex)
        {
            Vector2 xy = GameObject.Find("Back").transform.position;
            transform.position = xy;
            map = buildIndex;
        }

    }



}

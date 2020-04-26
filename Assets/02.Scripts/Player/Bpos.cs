using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bpos : MonoBehaviour
{
    // Start is called before the first frame update
    Player a;
    public bool sidemove;
    public float sidspeed;
    public float sidpower = 0.12f;
   
    int movevelo;
    private void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
       /* if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
        {
            a.anim.SetBool("isground", true);
            a.isGround = true;

        }*/
        if (other.gameObject.tag == "Move")
        {
            float blockspeeds;
            sidemove = other.gameObject.GetComponent<MoveBlock>().blockmove;
            a.moveblock = true;
            if (sidemove == false)
            {
               movevelo = 1;
            }
            else
            {
                movevelo = -1;
            }
            blockspeeds = sidspeed * sidpower * movevelo;
            a.mbs =blockspeeds;
           




        }

        if (other.gameObject.layer == 8 && a.state != Player.PlayerState.die && (a.state == Player.PlayerState.JumpFall ||a.state == Player.PlayerState.JumpDamage || a.state == Player.PlayerState.JumpAttack))
        {

           
            // a.anim.SetBool("isground", true);

            
           
            a.moveDir.y = 0;
            if (a.state != Player.PlayerState.JumpDamage)
            {
                a.state = Player.PlayerState.Wait;
            }
                //     StartCoroutine("Landai");



            // a.anim.SetBool("isground", true);

            //  a.anim.SetBool("Jumping", false);



        }
        if (other.gameObject.layer == 8)
        {
            a.anim.SetBool("isground", true);
            a.isGround = true;

        }

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
      
        
        if (other.gameObject.tag == "Move")
        {
        
        sidspeed = other.gameObject.GetComponent<MoveBlock>().movespeed;
        }
        if (other.gameObject.layer == 8&& a.state!=Player.PlayerState.die && (a.state==Player.PlayerState.JumpFall||a.state == Player.PlayerState.JumpDamage || a.state ==Player.PlayerState.JumpAttack))
        {

           
            // a.anim.SetBool("isground", true);

            a.moveDir.x = 0;



          //  StartCoroutine("Landai");
            a.moveDir.y = 0;
           
            if (a.state != Player.PlayerState.JumpDamage)
            {
                a.anim.SetTrigger("Land");
                a.state = Player.PlayerState.Wait;
            }
            // a.anim.SetBool("isground", true);

            //  a.anim.SetBool("Jumping", false);



        }

        if (other.gameObject.layer == 8)
        {
            a.anim.SetBool("isground", true);
            a.isGround = true;

        }


    }
    /*
    IEnumerator Landai()
    {
        
       // a.state = Player.PlayerState.Falls;
      
      //  a.transform.Translate(new Vector3(0, -0.13f, 0));
      //  a.Mpos.SetActive(false);
      //  yield return new WaitForSeconds(0.001f); 
       
       
     //   a.transform.Translate(new Vector3(0, +0.13f, 0));
        
        a.moveDir.y = 0;

       // a.Mpos.SetActive(true);
        

    }*/
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Map" && a.state!=Player.PlayerState.die)
        {
            a.Hp = 0;
            Destroy(a.gameObject);
            a.state = Player.PlayerState.die;
            GameObject.Find("Canvas").transform.Find("UI_dead").gameObject.SetActive(true);
        }

            if (other.gameObject.layer == 8)
            {
                a.isGround = false;
            a.anim.SetBool("isground", false);
         
            if (a.state == Player.PlayerState.Wait || a.state==Player.PlayerState.Attack)
            {
                a.state = Player.PlayerState.JumpFall;
            }
           

            //   a.anim.SetTrigger("Fall");
            //    a.anim.SetBool("isground", false);
            if (other.gameObject.tag == "Move")
                {

                a.moveblock = false;

                }
            if ((other.gameObject.tag == "down" || other.gameObject.tag=="time")&& a.state==Player.PlayerState.Sit)
            {
                a.state = Player.PlayerState.JumpFall;
                a.anim.SetTrigger("sitFall");
              //  a.transform.Translate(new Vector3(0, +0.45f, 0));
                //transform.Translate(new Vector3(0, -0.3f, 0));
                a.Mpos.SetActive(true);
                a.SMpos.SetActive(false);

            }

        }

    }
}

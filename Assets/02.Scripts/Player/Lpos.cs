using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lpos : MonoBehaviour
{
    public Collider2D Lp;
    Player p;
    float timer;
    float waitingTime;
    private void Start()
    {
        Lp = GetComponent<Collider2D>();
        p = Player.instance.GetComponent<Player>();
        timer = 0.0f;
        waitingTime = 0.5f;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {


        if (other.gameObject.layer == 8 && p.stop == false && p.Startstop == false && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && p.state == Player.PlayerState.Wait)
        {   

            if (timer > waitingTime)
            {
                var sm = SoundManager.Instance;
                sm.PlaySFX("beat");
                timer = 0;
            }
        }


    }
}
   
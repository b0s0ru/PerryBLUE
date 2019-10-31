using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpos : MonoBehaviour
{
    // Start is called before the first frame update
    Player a;
    private void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10 && (a.state == Player.PlayerState.Jump))
        {

            a.moveDir.y = -0.5f;
           


        }

    }
}

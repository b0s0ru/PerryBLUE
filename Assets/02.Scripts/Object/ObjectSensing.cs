using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSensing : MonoBehaviour
{
    static GameObject D;
    public int i;
    Player p;
    // Start is called before the first frame update
    private void Start()
    {
        D = GameObject.Find("Objectmanager");
        p = Player.instance.GetComponent<Player>();
    }
    void OnTriggerStay2D(Collider2D other)
    {



        if (other.gameObject.tag == "Mpos" && Input.GetKeyDown(KeyCode.UpArrow)&&p.isperry==false)
        {
         
            D.GetComponent<Objecimage>().Object(i);
        }

    }
   
}

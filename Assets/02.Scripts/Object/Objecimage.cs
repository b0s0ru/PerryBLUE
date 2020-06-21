using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objecimage : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] imagelist;
    Image t;
    Player P;
    public GameObject child;
    bool childs;
    void Start()
    {
        P = Player.instance.GetComponent<Player>();
        t = child.gameObject.GetComponent<Image>();
        childs = false;
    }

    // Update is called once per frame

    public void Object(int i)
    {
        childs = true;
        P.stop = true;
        child.gameObject.SetActive(true);
        t.sprite = imagelist[i];
       
        
       
       
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && childs==true)
        {
            childs = false;
            P.stop = false;
            child.gameObject.SetActive(false);
        }
    }
   
}

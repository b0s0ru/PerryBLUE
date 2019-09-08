using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changenumber : MonoBehaviour
{
    public int a;
    public Sprite [] sprites;
    private Image s;
    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        s = GetComponent <Image>();
        s.sprite= sprites[0];
    }

    // Update is called once per frame
   

    public void Up()
    {
        a++;
        if (a == 10)
        {
            a = 0;
        }
        Change();
    }
    public void Down()
    {
        a--;
        if (a == -1)
        {
            a = 9;
        }
        Change();
    }
    void Change()
    {
        s.sprite = sprites[a];
    }
}

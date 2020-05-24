using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Color colors;
    SpriteRenderer spr;
    void Start()
    {
        colors = new Color(255, 255,255, 0);
        colors.a = 0;
        Player.instance.GetComponent<Player>().stop = true;
        spr = Player.instance.GetComponent<SpriteRenderer>();
        spr.color = colors;
        FadeController.instance.FadeOut(0.5f);
        StartCoroutine("S");
        
    }
    IEnumerator S()
    {
        yield return new WaitForSeconds(5.5f);
        Destroy(GameObject.Find("Players").gameObject);
        colors = new Color(255, 255, 255, 255);
        
        spr.color = colors;
        Player.instance.GetComponent<Player>().stop = false;
    }
    // Update is called once per frame
    
}

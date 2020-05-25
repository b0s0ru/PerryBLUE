using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWake : MonoBehaviour
{
    SpriteRenderer s;
    Player a;
    // Start is called before the first frame update
    void Start()
    {
        s = Player.instance.GetComponent<SpriteRenderer>();
        s.color = new Color(255, 255, 255, 0);
        a = Player.instance.GetComponent<Player>();
        StartCoroutine("Wake");
    }

    // Update is called once per frame
    IEnumerator Wake()
    {
        yield return new WaitForSeconds(0.51f);
        a.stop = true;
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
        s.color = new Color(255, 255, 255, 255);
        Player.instance.GetComponent<Player>().stop = false;
    }
}

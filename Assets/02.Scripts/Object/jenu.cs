using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class jenu : MonoBehaviour
{
    // Start is called before the first frame update
    Player Player;
    FadeController black;
    bool water = false;
    private void Start()
    {
         Player= Player.instance.GetComponent<Player>();
        black = FadeController.instance.GetComponent<FadeController>();
    }
   
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        var singleton = Texts.Instance;


        if (other.gameObject.tag == "Mpos")
        {
            Player a = other.gameObject.transform.parent.GetComponent<Player>();
            if (a.Read[3])
            {
                singleton.TextOn(5.ToString());
                water = true;
            }
            else
            {
                singleton.TextOn(2.ToString());
            }
        }

    }

    private void Update()
    {
        if (water && Player.stop==false)
        {
            Player.stop = true;
            StartCoroutine("Scenemove");

        }
    }
    IEnumerator Scenemove()
    {
        black.FadeIn(0.3f);
        Destroy(Player.gameObject);

        yield return new WaitForSeconds(0.3f);
        PlayerPrefs.SetInt("map", 3);
        SceneManager.LoadScene(3);

    }

}


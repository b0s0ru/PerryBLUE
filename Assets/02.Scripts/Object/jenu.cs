using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class jenu : MonoBehaviour
{
    // Start is called before the first frame update
    Player Players;
    FadeController black;
    bool water = false;
    private void Start()
    {
         Players= Player.instance.GetComponent<Player>();
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
        if (water && Players.stop==false)
        {
            Players.stop = true;
            StartCoroutine("Scenemove");

        }
    }
    IEnumerator Scenemove()
    {
        black.FadeIn(0.3f);
        Players.Startstop = true;
        yield return new WaitForSeconds(0.3f);
        Destroy(Players.gameObject);
        PlayerPrefs.SetInt("map", 3);
        SceneManager.LoadScene(3);

    }

}


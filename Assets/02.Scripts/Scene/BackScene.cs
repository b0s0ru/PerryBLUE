using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackScene : MonoBehaviour
{


    int Scenenumber;
    FadeController black;
    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Scenenumber = SceneManager.GetActiveScene().buildIndex;
        black = FadeController.instance.GetComponent<FadeController>();
        Player = Player.instance.GetComponent<Player>();
    }

    // Update is called once per frame

    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos")
        {
            Player.Startstop = true;
            black.FadeIn(0.3f);
            StartCoroutine("Scenemove");
            
            


        }
    }
    IEnumerator Scenemove() {
        yield return new WaitForSeconds(0.3f);
       
        SceneManager.LoadScene(Scenenumber - 1);
    }

}





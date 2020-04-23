using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
   
    
    int Scenenumber;
    FadeController black;
    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Scenenumber = SceneManager.GetActiveScene().buildIndex;
        black = GameObject.Find("Canvas").transform.Find("black").GetComponent<FadeController>();
       Player= GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame

    void OnTriggerStay2D(Collider2D collision)

    {


        if (collision.transform.tag == "Mpos")
        {
            Player.stop = true;
            black.FadeIn(0.3f);
            StartCoroutine("Scenemove");
           
            


        }
    }
    IEnumerator Scenemove()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(Scenenumber + 1);
    }
}





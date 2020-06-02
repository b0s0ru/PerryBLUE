using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change : MonoBehaviour
{
    Player a;
    // Start is called before the first frame update
    void Start()
    {
        a =GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.state != Player.PlayerState.die)
        {
            Changes();
        }
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode level)
    {
        StopCoroutine("Finddust");
    }
        private void Changes()
    {
        if (Input.GetKey(KeyCode.LeftShift) && a.ischange == false && a.isperry == true && a.state == Player.PlayerState.Wait && a.stop == false && a.Startstop == false)
        {
            a.isperry = false;
            a.ischange = true;
            StartCoroutine(ChangeTime());
            a.eyesight.SetActive(false);
            a.anim.SetBool("Perry", false);
            a.Jumppower();

        }
        else if (Input.GetKey(KeyCode.LeftShift) && a.ischange == false && a.isperry == false && a.state == Player.PlayerState.Wait&& a.stop == false && a.Startstop == false)
        {
            a.isperry = true;
            a.ischange = true;
            StartCoroutine(ChangeTime());
            a.eyesight.SetActive(true);
            a.anim.SetBool("Perry", true);
            a.Jumppower();
        }

        if (a.isperry == false && a.Finedustdamage == false&& a.stop == false && a.state!=Player.PlayerState.die && a.Startstop == false)
        {
            StartCoroutine(Finedust());
            a.Finedustdamage = true;
        }

    }

    IEnumerator Finedust()
    {
        
            a.Hp -= 1;
            yield return new WaitForSeconds(1.5f);
            a.Finedustdamage = false;
        
    }

    IEnumerator ChangeTime()
    {

        yield return new WaitForSeconds(1f);
        a.ischange = false;

    }
}

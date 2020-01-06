using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Changes()
    {
        if (Input.GetKey(KeyCode.LeftShift) && a.ischange == false && a.isperry == true && a.state == Player.PlayerState.Wait)
        {
            a.isperry = false;
            a.ischange = true;
            StartCoroutine(ChangeTime());
            a.eyesight.SetActive(false);
            a.anim.SetBool("Perry", false);

        }
        else if (Input.GetKey(KeyCode.LeftShift) && a.ischange == false && a.isperry == false && a.state == Player.PlayerState.Wait)
        {
            a.isperry = true;
            a.ischange = true;
            StartCoroutine(ChangeTime());
            a.eyesight.SetActive(true);
            a.anim.SetBool("Perry", true);
        }

        if (a.isperry == false && a.Finedustdamage == false)
        {
            StartCoroutine(Finedust());
            a.Finedustdamage = true;
        }

    }
    IEnumerator Finedust()
    {
        a.Hp -= 1;
        yield return new WaitForSeconds(1f);
        a.Finedustdamage = false;
    }

    IEnumerator ChangeTime()
    {

        yield return new WaitForSeconds(2f);
        a.ischange = false;

    }
}

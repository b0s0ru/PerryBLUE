using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Hp : MonoBehaviour
{
    
    public float hps;
    public Image progress;
    public Text hp;
    public Player Players;
    //Use this for initialization
    private void Start()
    {

        progress = GetComponent<Image>();
        Players = GameObject.Find("Player").GetComponent<Player>();



    }

    // Update is called once per frame
    private void Update()
    {
        if (hps!=0)
        {
            hps = Players.Hp;
            progress.fillAmount = hps / 100;
            string str = hps.ToString();
            hp.text = str;
        }
    }
}

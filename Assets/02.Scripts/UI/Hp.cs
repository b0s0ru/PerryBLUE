using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Hp : MonoBehaviour
{
    
    public float hps;
    public Image progress;
    public Text hp;
   
    //Use this for initialization
    private void Start()
    {

        progress = GetComponent<Image>();
        
    }

    // Update is called once per frame
    private void Update()
    {

        progress.fillAmount = hps / 100;
        string str = hps.ToString();
        hp.text = str;
    }
}

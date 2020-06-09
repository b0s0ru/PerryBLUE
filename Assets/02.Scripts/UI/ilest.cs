using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ilest : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite [] ilests;
    public Image s;
    int k = 0;
    // Update is called once per frame
    public void Change(int i)
    {
        if (k != i)
        {
            k = i;
            s.sprite = ilests[i-1];
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

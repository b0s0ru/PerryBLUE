using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDown : MonoBehaviour
{

    Changenumber s;
    private void Start()
    {
        s = gameObject.transform.parent.GetComponent<Changenumber>();
    }



    void OnMouseUp()
    {
        s.Down();
    }




}

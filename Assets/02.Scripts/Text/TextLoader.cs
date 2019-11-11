
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        Setting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting()
    {
        Texts.instance.Set(index);

    }
    public void Work()
    {
       int s=Texts.instance.NormalScript(index);
       if(s==1){
            index++;
        }
        else
        {
            index++;
            GameObject.Find("Canvas/UI_normal_script/").SetActive(false);
        }

    }
    public void Work2()
    {
        //  Texts.instance.GetText2(names, log, yes, no);
    }


    public virtual void SpecialWorkyes()
    {

    }
    public virtual void SpecialWorkno()
    {

    }
}

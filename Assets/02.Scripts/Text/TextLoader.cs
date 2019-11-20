
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{

   public int index;
    static NextScene ns;
    GameObject nq;
    GameObject ny;
    int s;
    // Start is called before the first frame update
    void Start()
    {
        ns= GameObject.Find("UI_Script/nextSceneManager").GetComponent<NextScene>();
        nq = GameObject.Find("Canvas/UI_Script/UI_normal_script/").gameObject;
        ny = GameObject.Find("Canvas/UI_Script/UI_yesno_script/").gameObject;
        
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
        s=Texts.instance.NormalScript(index);
       if(s==1){
            index++;
        }
        else if (s==0)
        {
           
            nq.SetActive(false); nq.SetActive(false);
        }
        else if(s==-2)
        {
            ns.Scenemove();
        }
       else if (s == -3)
        {
            if (index == 36)
            {
                nq.SetActive(false);
                GameObject.Find("Canvas/GameObject").transform.Find("4_book").gameObject.SetActive(true);
            }
        }
        else
        {
            nq.SetActive(false);
            ny.SetActive(true);
            index++;
           
            
        }

    }

    public void ObjectsWork(int indexs)
    {
        Texts.instance.Set(indexs);
        index = indexs;
        nq.SetActive(true);
    }
    public void ObjectsWork2(int indexs)
    {
        Texts.instance.Set(indexs);
        ny.SetActive(true);
    }
    public void Work2()
    {
        //  Texts.instance.GetText2(names, log, yes, no);
    }

    //2씩 뺴준걸 기억할것
    public void SpecialWorkyes()
    {
        if (index == 12)
        {
            Destroy(GameObject.Find("Light").gameObject);
        }else if(index == 17)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("2_bacord").gameObject.SetActive(true);


        }
        else if (index == 28)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("3_examplig").gameObject.SetActive(true);
            
        }
        else if(index == 38)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("5_photo1").gameObject.SetActive(true);
          
        }
        index =Texts.instance.yesScript(index);
        nq.SetActive(true);
    }
    public void SpecialWorkno()
    {
        index=Texts.instance.noScript(index);
        nq.SetActive(true);
    }
}

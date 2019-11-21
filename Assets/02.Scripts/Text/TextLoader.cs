
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{

   public int index;
    static NextScene ns;
    GameObject nq;
    GameObject ny;
    public clear door;
    int s;
    public bool Allclear = false;
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
    public void Settings()
    {
        nq.SetActive(true);
        
        
            int q = 42;
            if (Allclear)
            {
                q = 43;

            }
        
        Texts.instance.Set(q);
        index = q;
    }
    public void Work()
    {

         


        s =Texts.instance.NormalScript(index);
      
         if (s == 1)
        {
           if (index == 64)
            {
                GameObject.Find("Canvas/GameObject").transform.Find("3_postit").gameObject.SetActive(true);
            }

            index++;
            
        }
        else if (s == 0)
        {

            nq.SetActive(false); nq.SetActive(false);
        }
        else if (s == -2)
        {
            ns.Scenemove();
        }
        else if (s == -3)
        {
            if (index == 36)
            {
                nq.SetActive(false);
                GameObject.Find("Canvas/GameObject").transform.Find("4_book").gameObject.SetActive(true);
                door.d[0] = true;
            }
            else if (index == 48)
            {
                nq.SetActive(false);
                GameObject.Find("Canvas/GameObject").transform.Find("1_calendar").gameObject.SetActive(true);
            }
            else if (index == 49)
            {
                nq.SetActive(false);
                GameObject.Find("Canvas").transform.Find("1-2_puzzle_0425").gameObject.SetActive(true);

            }
            else if (index == 52)
            {
                nq.SetActive(false);
                GameObject.Find("Canvas/GameObject").transform.Find("1_guarantee").gameObject.SetActive(true);
            }
            
            else if (index == 67)
            {
                nq.SetActive(false);
                GameObject.Find("Canvas").transform.Find("1-3_puzzle_52393").gameObject.SetActive(true);
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
        index = indexs;
        Texts.instance.Set2(indexs);
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
            door.d[4] = true;
        }
        else if (index == 17)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("2_bacord").gameObject.SetActive(true);
            index = Texts.instance.yesScript(index);
            nq.SetActive(true);
            door.d[1] = true;
        }
        else if (index == 28)

        {
            GameObject.Find("Canvas/GameObject").transform.Find("3_examplig").gameObject.SetActive(true);
            door.d[2] = true;

        }
        else if (index == 38)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("5_photo1").gameObject.SetActive(true);
            door.d[3] = true;
        }else if(index == 45)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("2_letter").gameObject.SetActive(true);
           
        }
        else if(index == 59)
        {
            GameObject.Find("Canvas/GameObject").transform.Find("2_memo").gameObject.SetActive(true);
        }
        
        else
        {
            index = Texts.instance.yesScript(index);
            nq.SetActive(true);
        }
    }
    public void SpecialWorkno()
    {
        index=Texts.instance.noScript(index);
        nq.SetActive(true);
    }
}

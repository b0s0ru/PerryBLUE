using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{





    public Text names;
    public Text maintext;
    public Text Selectmaintext;
    public Text Next;
    public int Nextnumber;
    public int QNextnumber;
    public Text choose1;
    public Text choose2;
    public int chosemove1;
    public int chosemove2;
    public Perry PerryDB;
    public int index = 0;
    public static Texts instance;
  //  public Scene x;
    private void Awake()
    {
        if (Texts.instance == null)
        {
            Texts.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    public void Update()
    {
         
    }
    public void Set(int index)
    {

        maintext.text = PerryDB.dataArray[index].Texts;
        names.text = PerryDB.dataArray[index].Name;
        Next.text = PerryDB.dataArray[index].Choose1;
       
    }
    public void Set2(int index)
    {

        Selectmaintext.text = PerryDB.dataArray[index].Texts;
        choose1.text = PerryDB.dataArray[index].Choose1;
        choose2.text = PerryDB.dataArray[index].Choose2;

    }

    public int NormalScript(int index)
    {
       
        Nextnumber = PerryDB.dataArray[index].Chosemove1;
        
        QNextnumber = PerryDB.dataArray[index+1].Chosemove2;
        
      
       if (Nextnumber == 0 || Nextnumber == -2)
        {
            return Nextnumber;
        }
        
        else if (Nextnumber == 1 && QNextnumber == -1)
        {
            maintext.text = PerryDB.dataArray[index + 1].Texts;
            names.text = PerryDB.dataArray[index + 1].Name;
            Next.text = PerryDB.dataArray[index + 1].Choose1;
            return Nextnumber;
        }
        else if(QNextnumber !=-1)
        {
            Selectmaintext.text= PerryDB.dataArray[index + 1].Texts;
            choose1.text= PerryDB.dataArray[index + 1].Choose1;
            choose2.text = PerryDB.dataArray[index + 1].Choose2;
            return index+1;
        }
        return Nextnumber;
        // x.a = PerryDB.dataArray[index].Chosemove1;
    }

   
    public int yesScript(int s)
    {
        int temp = PerryDB.dataArray[s].Chosemove1-2;
        Debug.Log(temp);
        maintext.text = PerryDB.dataArray[temp].Texts;
        names.text = PerryDB.dataArray[temp].Name;
        Next.text = PerryDB.dataArray[temp].Choose1;
        return temp;
    }
    public int noScript(int s)
    {
        
        int temp = PerryDB.dataArray[s].Chosemove2-2;
        maintext.text = PerryDB.dataArray[temp].Texts;
        names.text = PerryDB.dataArray[temp].Name;
        Next.text = PerryDB.dataArray[temp].Choose1;
        Debug.Log(temp);
        return temp;
    }
   
    /*
    public void SelectScript(int index)
    {
        Selectmaintext.text = PerryDB.dataArray[index].Text;
        yes2.text = LevelDB.dataArray[index].Chose1;
        no2.text = LevelDB.dataArray[index].Chose2;
        GameObject.Find("Canvas/UI_object_research/2option").SetActive(true);
        
    }*/



}

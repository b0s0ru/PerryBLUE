using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{





    public Text name;
    public Text maintext;
    public Text Selectmaintext;
    public Text Next;
    public int Nextnumber;
    public Text choose1;
    public Text chosse2;
    public Text chosemove1;
    public Text chosemove2;
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
        name.text = PerryDB.dataArray[index].Name;
        Next.text = PerryDB.dataArray[index].Choose1;
       
    }

    public int NormalScript(int index)
    {
        Nextnumber = PerryDB.dataArray[index].Chosemove1;
        if (Nextnumber == 1)
        {
            maintext.text = PerryDB.dataArray[index + 1].Texts;
            name.text = PerryDB.dataArray[index + 1].Name;
            Next.text = PerryDB.dataArray[index + 1].Choose1;
        }
        return Nextnumber;
        // x.a = PerryDB.dataArray[index].Chosemove1;
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

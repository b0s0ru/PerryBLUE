using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Texts : MonoBehaviour
{
    public New TextDB;
    public GameObject Text1;
    public Text player;
    public Text script;
    private static Texts instance;
    bool text = false;
    Player P;
    int i;
    public static Texts Instance

    {

        get

        {

            if (instance == null)

            {

                var obj = FindObjectOfType<Texts>();

                if (obj != null)

                {

                    instance = obj;

                }

                else

                {

                    var newSingleton = new GameObject("TextManager").AddComponent<Texts>();

                    instance = newSingleton;

                }

            }

            return instance;

        }

        private set

        {

            instance = value;

        }

    }

    /*public string Print(string name, string s)
    {
        
    }*/


    private void Awake()

    {
        
        var objs = FindObjectsOfType<Texts>();
       
      
        if (objs.Length != 1)

        {

            Destroy(gameObject);

            return;

        }
        Text1 = GameObject.Find("UI_Script").transform.Find("UI_normal_script").gameObject;
        P = GameObject.Find("Player").GetComponent<Player>();
        player = Text1.transform.GetChild(0).GetComponent<Text>();
        script = Text1.transform.GetChild(1).GetComponent<Text>();
        TextDB = Resources.Load("DB/New") as New;
        DontDestroyOnLoad(gameObject);
    }

    public void Setting()
    {
        Text1 = GameObject.Find("UI_Script").transform.Find("UI_normal_script").gameObject;
        P = GameObject.Find("Player").GetComponent<Player>();
        player = Text1.transform.GetChild(0).GetComponent<Text>();
        script = Text1.transform.GetChild(1).GetComponent<Text>();
        TextDB = Resources.Load("DB/New") as New;
    }
    
    private void Update()
    {
        if (Text1 == null)
        {
            Setting();
        }
        if (text)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                TextUp();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                TextOff();
            }
        }
    }
    public void TextOn(string a)
    {
        
        Text1.gameObject.SetActive(true);
        text = true;
       for(i=1; i<TextDB.dataArray.Length;i++)
        { 
            if (TextDB.dataArray[i].Number == a)
            {
               
                player.text =TextDB.dataArray[i].Name;
                script.text = TextDB.dataArray[i].Text;
                P.stop = true ;
                break;
                
            }
        }
       
    }
    public void TextUp()
    {
        if (TextDB.dataArray[i].Next == "1")
        {
            i++;
            player.text = TextDB.dataArray[i].Name;
            script.text = TextDB.dataArray[i].Text;
            
        }
        else if (TextDB.dataArray[i].Next == "0")
        {
            TextOff();
        }
       
    }
    public void TextOff()
    {
        Text1.gameObject.SetActive(false);
        text = false;
        P.stop = false;
    }
}



/*
public class Textss : MonoBehaviour
{





    public Texts names;
    public Texts mainTexts;
    public Texts SelectmainTexts;
    public Texts Next;
    public int Nextnumber;
    public int QNextnumber;
    public Texts choose1;
    public Texts choose2;
    public int chosemove1;
    public int chosemove2;
    public Perry PerryDB;
    public int index = 0;
    public static Textss instance;
  //  public Scene x;
    private void Awake()
    {
        if (Textss.instance == null)
        {
            Textss.instance = this;
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
   /*public void Set(int index)
    {

        mainTexts.Texts = PerryDB.dataArray[index].Textss;
        names.Texts = PerryDB.dataArray[index].Name;
        Next.Texts = PerryDB.dataArray[index].Choose1;
       
    }
    public void Set2(int index)
    {

        SelectmainTexts.Texts = PerryDB.dataArray[index].Textss;
        choose1.Texts = PerryDB.dataArray[index].Choose1;
        choose2.Texts = PerryDB.dataArray[index].Choose2;

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
            mainTexts.Texts = PerryDB.dataArray[index + 1].Textss;
            names.Texts = PerryDB.dataArray[index + 1].Name;
            Next.Texts = PerryDB.dataArray[index + 1].Choose1;
            return Nextnumber;
        }
        else if(QNextnumber !=-1)
        {
            SelectmainTexts.Texts= PerryDB.dataArray[index + 1].Textss;
            choose1.Texts= PerryDB.dataArray[index + 1].Choose1;
            choose2.Texts = PerryDB.dataArray[index + 1].Choose2;
            return index+1;
        }
        return Nextnumber;
        // x.a = PerryDB.dataArray[index].Chosemove1;
    }

   
    public int yesScript(int s)
    {
        int temp = PerryDB.dataArray[s].Chosemove1-2;
        Debug.Log(temp);
        mainTexts.Texts = PerryDB.dataArray[temp].Textss;
        names.Texts = PerryDB.dataArray[temp].Name;
        Next.Texts = PerryDB.dataArray[temp].Choose1;
        return temp;
    }
    public int noScript(int s)
    {
        
        int temp = PerryDB.dataArray[s].Chosemove2-2;
        mainTexts.Texts = PerryDB.dataArray[temp].Textss;
        names.Texts = PerryDB.dataArray[temp].Name;
        Next.Texts = PerryDB.dataArray[temp].Choose1;
        Debug.Log(temp);
        return temp;
    }
   
    /*
    public void SelectScript(int index)
    {
        SelectmainTexts.Texts = PerryDB.dataArray[index].Texts;
        yes2.Texts = LevelDB.dataArray[index].Chose1;
        no2.Texts = LevelDB.dataArray[index].Chose2;
        GameObject.Find("Canvas/UI_object_research/2option").SetActive(true);
        
    }*/



//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Texts : MonoBehaviour
{
    public New TextDB;
    public GameObject Text1;
    public TextMeshProUGUI player;
    public TextMeshProUGUI script;
    private static Texts instance;
    public GameObject image;
    bool text = false;
    Player P;
    string otext;
    string stext;
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
        Text1 = GameObject.Find("Canvas").transform.Find("P_script").gameObject;
        P = GameObject.Find("Player").GetComponent<Player>();
        player = Text1.transform.Find("background").transform.Find("back2").transform.Find("back3_name").transform.Find("Text_name").GetComponent<TextMeshProUGUI>();
        script = Text1.transform.Find("background").transform.Find("back2").transform.Find("Text_speak").GetComponent<TextMeshProUGUI>();
        TextDB = Resources.Load("DB/New") as New;
        image = Text1.transform.Find("background").transform.Find("back2").transform.Find("stand").gameObject;
        DontDestroyOnLoad(gameObject);
    }

    public void Setting()
    {
        Text1 = GameObject.Find("Canvas").transform.Find("P_script").gameObject;
        P = GameObject.Find("Player").GetComponent<Player>();
        player = Text1.transform.Find("background").transform.Find("back2").transform.Find("back3_name").transform.Find("Text_name").GetComponent<TextMeshProUGUI>();
        script = Text1.transform.Find("background").transform.Find("back2").transform.Find("Text_speak").GetComponent<TextMeshProUGUI>();
        image = Text1.transform.Find("background").transform.Find("back2").transform.Find("stand").gameObject;
        TextDB = Resources.Load("DB/New") as New;
    }

    private void Update()
    {
        if (Text1 == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Destroy(gameObject);
            }
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

        for (i = 1; i < TextDB.dataArray.Length; i++)
        {
            if (TextDB.dataArray[i].Number == a)
            {
                NewData read = TextDB.dataArray[i];
                string s = read.Name;

                player.text = s;
                if (s == "페리")
                {
                    Stands(0);

                }
                else if (s == "제누")
                {
                    if (read.State == "1")
                    {
                        Stands(1);
                    }
                    else if (read.State == "2")
                    {
                        Stands(2);
                    }

                }
                if (read.Ilest != "0")
                {
                    string Il = read.Ilest;
                    int changenum = int.Parse(Il);
                    GameObject o = GameObject.Find("Canvas").transform.Find("Ilest").gameObject;
                    if (o.activeSelf == false)
                    {
                        o.SetActive(true);
                    }
                    o.GetComponent<ilest>().IlestChange(changenum);
                }
                otext = read.Text;
                StartCoroutine("TypingAction");

                P.stop = true;
                break;

            }
        }

    }
    void Stands(int so)
    {
        int j;
        for (j = 0; j < image.transform.childCount; j++)
        {
            if (j != so)
            {
                image.transform.GetChild(j).gameObject.SetActive(false);
            }
            image.transform.GetChild(so).gameObject.SetActive(true);
        }

    }
    public void TextUp()
    {
        if (TextDB.dataArray[i].Next == "1")
        {
            i++;
            NewData read = TextDB.dataArray[i];
            string s = read.Name;
            player.text = s;
            otext = read.Text;

            if (s == "페리")
            {
                Stands(0);

            }
            else if (s == "제누")
            {

                if (read.State == "1")
                {
                    Stands(1);

                }
                else if (read.State == "2")
                {
                    Stands(2);
                }

            }

            StopCoroutine("TypingAction");
            StartCoroutine("TypingAction");
            if (read.Ilest != "0")
            {
                string Il = read.Ilest;
                int changenum = int.Parse(Il);
                GameObject o = GameObject.Find("Canvas").transform.Find("Ilest").gameObject;
                if (o.activeSelf == false)
                {
                    o.SetActive(true);
                }
                o.GetComponent<ilest>().IlestChange(changenum);
            }
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

        if (null != GameObject.Find("Canvas").transform.Find("Ilest"))
        {
            GameObject q = GameObject.Find("Canvas").transform.Find("Ilest").gameObject;
            if (q.activeSelf == true)
            {
                q.SetActive(false);
            }
        }

    }

    IEnumerator TypingAction()
    {
        for (int i = 0; i <=otext.Length; i++)
        {

            

            stext += otext.Substring(0, i);
            script.text = stext;
            stext = "";
            yield return new WaitForSeconds(0.045f);
        }
        
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

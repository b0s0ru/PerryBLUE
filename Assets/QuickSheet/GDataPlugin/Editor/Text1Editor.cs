using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Text1))]
public class Text1Editor : BaseGoogleEditor<Text1>
{	    
    public override bool Load()
    {        
        Text1 targetData = target as Text1;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<Text1Data>(targetData.WorksheetName) ?? db.CreateTable<Text1Data>(targetData.WorksheetName);
        
        List<Text1Data> myDataList = new List<Text1Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            Text1Data data = new Text1Data();
            
            data = Cloner.DeepCopy<Text1Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

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
[CustomEditor(typeof(New))]
public class NewEditor : BaseGoogleEditor<New>
{	    
    public override bool Load()
    {        
        New targetData = target as New;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<NewData>(targetData.WorksheetName) ?? db.CreateTable<NewData>(targetData.WorksheetName);
        
        List<NewData> myDataList = new List<NewData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            NewData data = new NewData();
            
            data = Cloner.DeepCopy<NewData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

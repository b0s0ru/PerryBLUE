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
[CustomEditor(typeof(Perry))]
public class PerryEditor : BaseGoogleEditor<Perry>
{	    
    public override bool Load()
    {        
        Perry targetData = target as Perry;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<PerryData>(targetData.WorksheetName) ?? db.CreateTable<PerryData>(targetData.WorksheetName);
        
        List<PerryData> myDataList = new List<PerryData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            PerryData data = new PerryData();
            
            data = Cloner.DeepCopy<PerryData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

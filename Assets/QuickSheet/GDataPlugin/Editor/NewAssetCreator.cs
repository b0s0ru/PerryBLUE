using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/New")]
    public static void CreateNewAssetFile()
    {
        New asset = CustomAssetUtility.CreateAsset<New>();
        asset.SheetName = "Blue";
        asset.WorksheetName = "New";
        EditorUtility.SetDirty(asset);        
    }
    
}
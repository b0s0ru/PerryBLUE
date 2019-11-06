using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Perry")]
    public static void CreatePerryAssetFile()
    {
        Perry asset = CustomAssetUtility.CreateAsset<Perry>();
        asset.SheetName = "Blue";
        asset.WorksheetName = "Perry";
        EditorUtility.SetDirty(asset);        
    }
    
}
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Text1")]
    public static void CreateText1AssetFile()
    {
        Text1 asset = CustomAssetUtility.CreateAsset<Text1>();
        asset.SheetName = "Blue";
        asset.WorksheetName = "Text1";
        EditorUtility.SetDirty(asset);        
    }
    
}
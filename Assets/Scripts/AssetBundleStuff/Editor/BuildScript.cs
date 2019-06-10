using UnityEditor;
using System.IO;
using UnityEngine;

public class BuildScript : Editor {
    //creates menu option under assets to build assetbundles
    [MenuItem("Assets/Build AssetBundles")]
    //builds assetbundle
    static void BuildAllAssetBundles() {
        string assetBundleDirectory = "/Users/emicb/Desktop/Bundle";
        string assetBundleURL = "https://emicb.github.io/TestAssetBundles";
        //location to build asset bundle
        string path = assetBundleURL;
        //creates local directory if it does not exist already
        if (path == assetBundleDirectory && !Directory.Exists(path)) {
            Directory.CreateDirectory(path);
            Debug.Log("Created new directory " + path);
        }
        //builds to directory, uses LZMA compression & LZ4 recompression, builds to user's build target
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}

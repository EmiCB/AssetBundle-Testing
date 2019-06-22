using UnityEditor;
using System.IO;
using UnityEngine;

public class BuildScript : Editor {
    //creates menu option under assets to build assetbundles
    [MenuItem("Assets/Build AssetBundles")]
    //builds assetbundle
    static void BuildAllAssetBundles() {
        //NOTE add new directory to this array when adding build targets
        string[] buildTargetSubDirs = {"", "/iOS", "/Android"};
        //preset paths to build the bundle
        string assetBundleDirectory = "/Users/emicb/Desktop/TestBundles";
        string assetBundleURL = "https://emicb.github.io/TestAssetBundles";
        //location to build asset bundle
        string path = assetBundleDirectory;

        //creates local directories if they does not exist already
        for(int targets = 0; targets < buildTargetSubDirs.Length; targets++) {
            string newPath = path + buildTargetSubDirs[targets];
            if (path == assetBundleDirectory && !Directory.Exists(newPath)) {
                Directory.CreateDirectory(newPath);
                Debug.Log("Created new directory " + newPath);
            }
        }

        //NOTE copy and paste lines below and change target and path for aditional build targets
        //builds to directory, uses LZMA compression & LZ4 recompression, builds for iOS
        BuildPipeline.BuildAssetBundles(path + "/iOS", BuildAssetBundleOptions.None, BuildTarget.iOS);
        //builds to directory, uses LZMA compression & LZ4 recompression, builds for Android
        //BuildPipeline.BuildAssetBundles(path + "/Android", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
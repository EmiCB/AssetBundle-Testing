using UnityEditor;
using System.IO;

public class BuildScript : Editor {
    //creates menu option under assets to build assetbundles
    [MenuItem("Assets/Build AssetBundles")]
    //builds assetbundle
    static void BuildAllAssetBundles() {
        //location to build asset bundle
        string assetBundleDirectory = "/Users/emicb/Desktop/TestBundles";
        //creates directory if it does not exist already
        if (!Directory.Exists(assetBundleDirectory)) {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        //builds to directory, uses LZMA compression & LZ4 recompression, builds to user's build target
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour {
    string assetBundleServerURL = "https://www.dropbox.com/sh/n3frhilnpkozbmu/AABwkFnjxgwUJcQ0zSWuhnpJa/monkeys.unity3d?dl=1";
    UnityWebRequest webRequest;
    AssetBundle ab;

    void Start() {
        StartCoroutine(GetAssetBundle());
    }

    //coroutine to get assetbundle from webserver
    IEnumerator GetAssetBundle() {
        //web request to get assetbundle from webserver, skips crc
        webRequest = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleServerURL);
        Debug.Log(webRequest == null ? "No web request" : "Web request exists");
        yield return webRequest.SendWebRequest();
        //loads asset bundle
        ab = DownloadHandlerAssetBundle.GetContent(webRequest);
        Debug.Log(ab == null ? "Failed to load AssetBundle" : "Successfully Loaded AssetBundle");
        //instantiate object from assetbundle
        GameObject cube = ab.LoadAsset<GameObject>("monkey_lp");
    }
}

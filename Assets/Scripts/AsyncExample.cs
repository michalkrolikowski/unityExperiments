using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class AsyncExample : MonoBehaviour
{


    async void Start() {
        Debug.Log($"Start");

        var googleTask = LoadWebsiteText("www.google.com");
        var eiduTask = LoadWebsiteText("www.eidu.com");
        var coroutine = WaitingCoroutine();

        await Task.WhenAll(googleTask, eiduTask, (Task) coroutine);

        var google = await googleTask;
        var eidu = await eiduTask;
        var asdf = await coroutine;

        Debug.Log($"Google: {google.Substring(0, 100)}");
        Debug.Log($"EIDU: {eidu.Substring(0, 100)}");
        Debug.Log($"asdf: {asdf}");

        //await Task.Delay(TimeSpan.FromSeconds(1));
    }

    async Task<string> LoadWebsiteText(string address) {
        var request = UnityWebRequest.Get(address);
        await request.SendWebRequest();
        return request.downloadHandler.text;
    }

    IEnumerator WaitingCoroutine() {
        yield return new WaitForSeconds(1f);
        yield return "asdf";
    }
}

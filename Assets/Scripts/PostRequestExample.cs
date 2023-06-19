using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class PostRequestExample : MonoBehaviour
{
    public byte[] byteData;
    public string FileType;
    public string fileURL;

    public void GetFile(byte[] byteData, string FileType)
    {
        StartCoroutine(SendRequest(byteData, FileType));
    }

    IEnumerator SendRequest(byte[] byteData, string FileType)
    {
        string url = "https://qr.writingeraser.ru/upload"; 
        using UnityWebRequest request = UnityWebRequest.Post(url, "");
        request.uploadHandler = new UploadHandlerRaw(byteData);
        request.SetRequestHeader("content-length", byteData.Length.ToString());
        request.SetRequestHeader("x-file-extension", FileType);

        yield return request.SendWebRequest();
        Debug.Log(request.result);

        if (request.result == UnityWebRequest.Result.Success)
        {
            fileURL = "https://qr.writingeraser.ru" + request.downloadHandler.text;
            Debug.Log("File URL: " + fileURL);

        }
        else
        {
            Debug.Log("Error uploading file: " + request.error);
        }
    }
}

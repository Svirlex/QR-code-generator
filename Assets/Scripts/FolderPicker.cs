using UnityEngine;
using UnityEngine.UI;
using SFB;
using System.IO;

public class FolderPicker : MonoBehaviour
{
    public string FolderPath;

    [SerializeField] public Text selectedFolder;

    public void OpenFolderPicker()
    {
        string[] paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);

        if (paths.Length > 0)
        {
            string folderPath = paths[0];

            // Do something with the folderPath
            Debug.Log("Selected folder path: " + folderPath);
            //FolderPath = folderPath;


            //selectedFolder.ToString() = FolderPath;

            GetComponent<TextureDownloader>().DownloadTexture();
        }
        else
        {
            Debug.Log("No folder selected.");
        }
    }
}

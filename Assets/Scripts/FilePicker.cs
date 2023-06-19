using UnityEngine;
using UnityEngine.UI;
using SFB;
using System.IO;

public class FilePicker : MonoBehaviour
{
    public PostRequestExample PRE;
    public byte[] FileBytes;
    public string FileType;
    public string FileName;
    private ExtensionFilter[] fileExtensions = new[] { new ExtensionFilter("All Files", "*") };

    [SerializeField] Text selectedFile;

    public void OpenFilePicker()
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Select File", "", fileExtensions, false);

        if (paths.Length > 0)
        {
            string filePath = paths[0];
            byte[] fileBytes = File.ReadAllBytes(filePath);
            string fileType = Path.GetExtension(filePath);
            string fileName = Path.GetFileName(filePath);

            // Do something with the fileBytes and fileType
            Debug.Log("Selected file bytes: " + fileBytes.Length + " bytes");
            Debug.Log("Selected file type: " + fileType);
            Debug.Log("Selected file name: " + fileName);
            FileBytes = fileBytes;
            FileType = fileType;
            FileName = fileName;


            // Ensure that PRE is not null
            if (PRE == null)
            {
                PRE = GetComponent<PostRequestExample>();
            }

            selectedFile.text = FileName;

            // Call the GetFile function on the PRE instance
            //PRE.GetFile(FileBytes, FileType);
            Debug.Log("under PRE");
        }
        else
        {
            Debug.Log("No file selected.");
        }
    }




}

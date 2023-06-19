using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileInfo : MonoBehaviour
{
    public byte[] FileData;
    public string FileType;
    public PostRequestExample PRE;

    public string fileURL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fileURL = GetComponent<PostRequestExample>().fileURL;
    }

    public void confirmFile()
    {
        FileData = GetComponent<FilePicker>().FileBytes;
        FileType = GetComponent<FilePicker>().FileType;

        PRE.GetFile(FileData, FileType);
    }
}

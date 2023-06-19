using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextureDownloader : MonoBehaviour
{
    public RawImage textureToDownload;
    public GameObject _slider;

    private string fileName;
    public Text filePathText;

    public void DownloadTexture()
    {
        // Convert the texture to bytes
        Texture2D _texture = textureToDownload.texture as Texture2D;
        byte[] bytes = _texture.EncodeToPNG();

        if (bytes != null)
        {
            if (_slider.GetComponent<Slider>().value == 0)
            {
                fileName = $"Texture_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";

            }
            else
            {

                fileName = Path.GetFileNameWithoutExtension(GetComponent<FilePicker>().FileName + ".png");

            }

            // Define the file path where the texture will be saved
            string filePath = Path.Combine(Application.persistentDataPath, fileName);

            // Write the bytes to a file
            File.WriteAllBytes(filePath, bytes);

            // Output the file path in the console
            Debug.Log("Texture downloaded to: " + filePath);

            filePathText.gameObject.SetActive(true);
            filePathText.text = "Файл был скачан по следующему пути: " + filePath;


        }
    }

        
    public void CopyTextToClipboard()
    {
        string text = Application.persistentDataPath.ToString();
        GUIUtility.systemCopyBuffer = text;
    }
}

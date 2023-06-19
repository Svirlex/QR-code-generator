using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using TMPro;

public class QRCodeGenerator : MonoBehaviour
{
    public RawImage qrCodeImage;
    public InputField _inputField;
    public Color blackColorInput;
    public Color whiteColorInput;

    public GameObject _slider;
    public PostRequestExample PRE;


    private void Update()
    {
        blackColorInput = GetComponent<ColorChanger>().BlackFcp;
        whiteColorInput = GetComponent<ColorChanger>().WhiteFcp;

    }
    public void Generate()
    {
        if (_slider.GetComponent<Slider>().value == 0)
        {
            if (_inputField.text != "")
            {
                qrCodeImage.gameObject.SetActive(true);
                string data = _inputField.text;

                Texture2D qrCodeTexture = GenerateQRCode(data, 256, 256);
                qrCodeImage.texture = qrCodeTexture;
            }
        }
        else
        {
            qrCodeImage.gameObject.SetActive(true);

            string data = GetComponent<FileInfo>().fileURL;

            Texture2D qrCodeTexture = GenerateQRCode(data, 256, 256);
            qrCodeImage.texture = qrCodeTexture;


        }
        
    }

    private Texture2D GenerateQRCode(string data, int width, int height)
    {
        BarcodeWriter barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                CharacterSet = "UTF-8",
                Height = height,
                Width = width
            }
        };

        Color32[] pixels = barcodeWriter.Write(data);
        Texture2D qrCodeTexture = new Texture2D(width, height);
        qrCodeTexture.SetPixels32(pixels);

        Color32 newBlackColor = blackColorInput;
        Color32 newWhiteColor = whiteColorInput;

        for (int i = 0; i < pixels.Length; i++)
        {      
            
            if (pixels[i] == Color.black) // Check for black color
            {
                pixels[i] = newBlackColor;
            }
            else if (pixels[i] == Color.white) // Check for white color
            {
                pixels[i] = newWhiteColor;
            }
        }

        qrCodeTexture.SetPixels32(pixels);
        qrCodeTexture.Apply();

        qrCodeTexture.Apply();

        return qrCodeTexture;
    }
}

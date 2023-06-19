using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCube : MonoBehaviour
{
    public InputField _input;
    public Color _color;
    //public GameObject image;

    private void Update()
    {
        ChangeImageColorByHex();

    }

    private void ChangeImageColorByHex()
    {
        if (ColorUtility.TryParseHtmlString(_input.text, out _color))
        {
            GetComponent<Image>().color = _color;
        }
    }
}

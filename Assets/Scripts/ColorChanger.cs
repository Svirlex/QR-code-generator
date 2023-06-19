using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] FlexibleColorPicker fcp;
    [SerializeField] public Color BlackFcp;
    [SerializeField] public Color WhiteFcp;
    [SerializeField] public GameObject whiteImage;
    [SerializeField] public GameObject blackImage;
    // Start is called before the first frame update

    private void Update()
    {
        BlackFcp = blackImage.GetComponent<ColorCube>()._color;
        WhiteFcp = whiteImage.GetComponent<ColorCube>()._color;
    }
    //public void changeBlack()
    //{
    //    BlackFcp = fcp.color;
    //    Debug.Log("B Changed to: " +  fcp.color);
    //}
    //public void changeWhite()
    //{
    //    WhiteFcp = fcp.color;
    //    Debug.Log("W Changed to: " + fcp.color);
    //}
}

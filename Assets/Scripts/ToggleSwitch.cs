using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] GameObject _slider;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject filePicker;
    [SerializeField] GameObject fileName;
    public void Activate()
    {
        if (_slider.GetComponent<Slider>().value == 0)
        {
            inputField.SetActive(true);

            fileName.SetActive(false);
            filePicker.SetActive(false);
        }
        else
        {
            fileName.SetActive(true);
            filePicker.SetActive(true);

            inputField.SetActive(false);
            

        }
    }
}

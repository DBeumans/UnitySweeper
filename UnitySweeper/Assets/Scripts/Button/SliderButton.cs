using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderButton : MonoBehaviour {
    [SerializeField]
    private int maxValue;
    [SerializeField]
    private int minValue;
    [SerializeField]
    private float currentValue;
    [SerializeField]
    private bool useWholeNumbers;

    [SerializeField]
    private Text sliderText;

    private Slider slider;

    private GameOptions gameOptions;

    private void Start()
    {
        gameOptions = FindObjectOfType<GameOptions>();
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        slider.maxValue = maxValue;
        slider.minValue = minValue;
        slider.value = currentValue;
        slider.wholeNumbers = useWholeNumbers;
    }

    private void ValueChangeCheck()
    {
        if(this.gameObject.name.Contains("Width"))
        {
            gameOptions.GetWidth = (int)slider.value;

        }

        if(this.gameObject.name.Contains("Height"))
        {
            gameOptions.GetHeight = (int)slider.value;

        }

        sliderText.text = ""+slider.value;
    }
}

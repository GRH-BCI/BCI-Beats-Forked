using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBehaviour : MonoBehaviour
{

    public Text loopText;
    public Slider loopSlider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSliderChange()
    {
        loopText.text = "Current Loop Amount: " + loopSlider.value;
        AudioManager.Instance.SetLoopLimit((int)loopSlider.value);
    }
}

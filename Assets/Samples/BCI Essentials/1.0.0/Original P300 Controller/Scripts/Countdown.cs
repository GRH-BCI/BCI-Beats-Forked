using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    // Start is called before the first frame update

    void Start()
    {
        watch.Start();

        if (textMeshPro != null)
        {
            // Access and modify the text property
            textMeshPro.text = "Hello, Unity!";
        }
        else
        {
            // Log an error if the TextMeshPro component is not assigned
            Debug.LogError("TextMeshPro component is not assigned!");
        }

    }

    // Update is called once per frame
    void Update()
    {

        textMeshPro.text = Math.Ceiling(((double)(9000 - watch.ElapsedMilliseconds)/1000)).ToString();

        if (watch.ElapsedMilliseconds > 9000)
        {
            //SceneManager.LoadScene("Assets/Scenes/ChooseInstrument.unity");
            SceneManager.LoadScene("Assets/Samples/BCI Essentials/1.0.0/Original P300 Controller/Scenes/P300Training.unity");
        };

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingCountdown : MonoBehaviour
{
    private System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        watch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (watch.ElapsedMilliseconds > 10000)
        {
             SceneSwitcher.Instance.LoadScene("Assets/Scenes/ChooseInstrument.unity");
        };

    }
}

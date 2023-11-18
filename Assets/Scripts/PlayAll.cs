using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAll : MonoBehaviour
{

    [SerializeField] public Button b;
    private System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    private long slowdown = 0;
    // Start is called before the first frame update
    void Start()
    {
        watch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        b.onClick.AddListener(OnButtonClick);

        
    }

    private void OnButtonClick()
    {
        // Use the AudioSource component to play the audio clip
        if (watch.ElapsedMilliseconds >= slowdown)
        {
            slowdown = watch.ElapsedMilliseconds + 8000;
            foreach (AudioClip c in StoreSounds.noises)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource = gameObject.AddComponent<AudioSource>();
                // Assign the audio clip to the AudioSource
                audioSource.clip = c;

                // Play the audio
                audioSource.Play();

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    [SerializeField] public AudioClip melody1;
    [SerializeField] public AudioClip melody2;
    [SerializeField] public AudioClip melody3;

    [SerializeField] public Button play1;
    [SerializeField] public Button play2;
    [SerializeField] public Button play3;

    // Start is called before the first frame update
    void Start()
    {
        play1.onClick.AddListener(OnButtonClick1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnButtonClick1()
    {
        // Use the AudioSource component to play the audio clip
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there is no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource
        audioSource.clip = melody1;

        // Play the audio
        audioSource.Play();
    }
    private void OnButtonClick2()
    {
        // Handle button click logic here
        Debug.Log("Button Clicked!");
    }
    private void OnButtonClick3()
    {
        // Handle button click logic here
        Debug.Log("Button Clicked!");
    }
}

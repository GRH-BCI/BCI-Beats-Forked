using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour
{
    [SerializeField] public AudioClip melody1;
    [SerializeField] public AudioClip melody2;
    [SerializeField] public AudioClip melody3;

    [SerializeField] public Button play1;
    [SerializeField] public Button play2;
    [SerializeField] public Button play3;

    [SerializeField] public Button choose1;
    [SerializeField] public Button choose2;
    [SerializeField] public Button choose3;

    // Start is called before the first frame update
    void Start()
    {
        play1.onClick.AddListener(OnButtonClick1);
        play2.onClick.AddListener(OnButtonClick2);
        play3.onClick.AddListener(OnButtonClick3);
        choose1.onClick.AddListener(OnButtonClick4);
        choose2.onClick.AddListener(OnButtonClick5);
        choose3.onClick.AddListener(OnButtonClick6);
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
        // Use the AudioSource component to play the audio clip
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there is no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource
        audioSource.clip = melody2;

        // Play the audio
        audioSource.Play();
    }
    private void OnButtonClick3()
    {
        // Use the AudioSource component to play the audio clip
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there is no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource
        audioSource.clip = melody3;

        // Play the audio
        audioSource.Play();
    }
    private void OnButtonClick4()
    {
        StoreSounds.noises.Add(melody1);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }
    private void OnButtonClick5()
    {
        StoreSounds.noises.Add(melody2);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");

    }
    private void OnButtonClick6()
    {
        StoreSounds.noises.Add(melody3);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");

    }
}

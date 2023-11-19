using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionHolderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadTrainingPhaseScene() {
        SceneManager.LoadScene("Assets/Scenes/TrainingSplash.unity");
    }

    public void LoadChooseInstrumentScene()
    {
        SceneManager.LoadScene("Assets/Scenes/ChooseInstrument.unity");
    }

    public void LoadPianoMusicScene()
    {
        SceneManager.LoadScene("Assets/Scenes/PianoMusic.unity");
    }

    public void LoadGuitarMusicScene()
    {
        SceneManager.LoadScene("Assets/Scenes/GuitarMusic.unity");
    }

    public void LoadBassMusicScene()
    {
        SceneManager.LoadScene("Assets/Scenes/BassMusic.unity");
    }

    public void LoadDrumsMusicScene()
    {
        SceneManager.LoadScene("Assets/Scenes/DrumMusic.unity");
    }

    public void LoadBandScreenScene()
    {
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody1()
    {
        AudioClip melody = Resources.Load<AudioClip>("Piano1");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody2()
    {
        AudioClip melody = Resources.Load<AudioClip>("Piano2");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody3()
    {
        AudioClip melody = Resources.Load<AudioClip>("Piano3");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void GuitarMelody1()
    {
        AudioClip melody = Resources.Load<AudioClip>("Guitar1");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void GuitarMelody2()
    {
        AudioClip melody = Resources.Load<AudioClip>("Guitar2");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void GuitarMelody3()
    {
        AudioClip melody = Resources.Load<AudioClip>("Guitar3");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void DrumsMelody1()
    {
        AudioClip melody = Resources.Load<AudioClip>("Drums1");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void DrumsMelody2()
    {
        AudioClip melody = Resources.Load<AudioClip>("Drums2");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void DrumsMelody3()
    {
        AudioClip melody = Resources.Load<AudioClip>("Drums3");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void BassMelody1()
    {
        AudioClip melody = Resources.Load<AudioClip>("Bass1");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void BassMelody2()
    {
        AudioClip melody = Resources.Load<AudioClip>("Bass2");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void BassMelody3()
    {
        AudioClip melody = Resources.Load<AudioClip>("Bass1");
        StoreSounds.noises.Add(melody);
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody1Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Piano1");
   
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void PianoMelody2Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Piano2");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void PianoMelody3Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Piano3");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void GuitarMelody1Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Guitar1");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void GuitarMelody2Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Guitar2");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void GuitarMelody3Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Guitar3");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void DrumsMelody1Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Drums1");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void DrumsMelody2Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Drums2");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void DrumsMelody3Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Drums3");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void BassMelody1Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Bass1");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void BassMelody2Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Bass2");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void BassMelody3Play()
    {
        AudioClip melody = Resources.Load<AudioClip>("Bass1");
        StoreSounds.noises.Add(melody);
        audioSource.clip = melody;
        audioSource.Play();
    }

    public void PlayAll()
    {
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

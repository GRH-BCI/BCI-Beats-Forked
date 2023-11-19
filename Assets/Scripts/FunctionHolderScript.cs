using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionHolderScript : MonoBehaviour
{

    public SpriteRenderer pauseButton;
    public Sprite pauseButtonRender;
    public Sprite playButtonRender;


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
        // just trying to make sure no sounds play when switching away from the band screen, hacky solution af
        StoreSounds.isPlaying = false;
        AudioListener.volume = 0;
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
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody1()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Piano1");
        //StoreSounds.noises.Add(melody);
        StoreSounds.pianoTrack = 1;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody2()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Piano2");
        //StoreSounds.noises.Add(melody);
        StoreSounds.pianoTrack = 2;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody3()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Piano3");
        //StoreSounds.noises.Add(melody);
        StoreSounds.pianoTrack = 3;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void GuitarMelody1()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Guitar1");
        //StoreSounds.noises.Add(melody);
        StoreSounds.guitarTrack = 1;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void GuitarMelody2()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Guitar2");
        //StoreSounds.noises.Add(melody);
        StoreSounds.guitarTrack = 2;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void GuitarMelody3()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Guitar3");
        //StoreSounds.noises.Add(melody);
        StoreSounds.guitarTrack = 3;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void DrumsMelody1()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Drums1");
        //StoreSounds.noises.Add(melody);
        StoreSounds.drumTrack = 1;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void DrumsMelody2()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Drums2");
        //StoreSounds.noises.Add(melody);
        StoreSounds.drumTrack = 2;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void DrumsMelody3()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Drums3");
        //StoreSounds.noises.Add(melody);
        StoreSounds.drumTrack = 3;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void BassMelody1()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Bass1");
        //StoreSounds.noises.Add(melody);
        StoreSounds.bassTrack = 1;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void BassMelody2()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Bass2");
        //StoreSounds.noises.Add(melody);
        StoreSounds.bassTrack = 2;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void BassMelody3()
    {
        //AudioClip melody = Resources.Load<AudioClip>("Bass1");
        //StoreSounds.noises.Add(melody);
        StoreSounds.bassTrack = 3;
        AudioListener.volume = 1;
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }

    public void PianoMelody1Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Piano1");

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void PianoMelody2Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Piano2");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void PianoMelody3Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Piano3");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void GuitarMelody1Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Guitar1");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void GuitarMelody2Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Guitar2");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void GuitarMelody3Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Guitar3");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void DrumsMelody1Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Drums1");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void DrumsMelody2Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Drums2");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void DrumsMelody3Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Drums3");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void BassMelody1Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Bass1");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void BassMelody2Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Bass2");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void BassMelody3Play()
    {
        AudioListener.volume = 1;
        AudioClip melody = Resources.Load<AudioClip>("Bass1");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the audio clip to the AudioSource
        audioSource.clip = melody;

        // Play the audio
        audioSource.Play();
    }

    public void PlayAll()
    {
        foreach (AudioClip c in StoreSounds.noises)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            // Assign the audio clip to the AudioSource
            audioSource.clip = c;

            // Play the audio
            audioSource.Play();

        }
    }

    public void Reset()
    {
        //StoreSounds.noises = new List<AudioClip>();
        StoreSounds.pianoTrack = 0;
        StoreSounds.guitarTrack = 0;
        StoreSounds.bassTrack = 0;
        StoreSounds.drumTrack = 0;
        StoreSounds.isPlaying = false;
    }

    public void toggleMusic() {
        if (StoreSounds.isPlaying) {
            StoreSounds.isPlaying = false;
            AudioListener.volume = 0;
            pauseButton.sprite = playButtonRender;
        }
        else {
            StoreSounds.isPlaying = true;
            AudioListener.volume = 1;
            pauseButton.sprite = pauseButtonRender;
        }
    }

}

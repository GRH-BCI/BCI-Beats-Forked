using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FunctionHolderScript : MonoBehaviour
{

    public SpriteRenderer pauseButton;
    public Sprite pauseButtonRender;
    public Sprite playButtonRender;
    public Text resetText;
    public List<AudioClip> noises = new List<AudioClip>();


    private void Awake()
    {
        // Ensure that this GameObject persists across scene changes
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTrainingPhaseScene() => SceneSwitcher.Instance.LoadScene("Assets/Scenes/TrainingSplash.unity");
    public void LoadChooseInstrumentScene() 
    {
        AudioManager.Instance.StopTestListener();
        AudioManager.Instance.StopMainTrack();
        SceneSwitcher.Instance.LoadScene("Assets/Scenes/ChooseInstrument.unity");
    }

    public void LoadPianoMusicScene() => SceneSwitcher.Instance.LoadScene("Assets/Scenes/PianoMusic.unity", PianoMelody1Play);
    public void LoadGuitarMusicScene() => SceneSwitcher.Instance.LoadScene("Assets/Scenes/GuitarMusic.unity", GuitarMelody1Play);
    public void LoadBassMusicScene() => SceneSwitcher.Instance.LoadScene("Assets/Scenes/BassMusic.unity", BassMelody1Play);
    public void LoadDrumsMusicScene() => SceneSwitcher.Instance.LoadScene("Assets/Scenes/DrumMusic.unity", DrumsMelody1Play);
    public void LoadBandScreenScene() => SceneSwitcher.Instance.LoadScene("Assets/Scenes/BandScreen.unity");


    public void PianoMelody1() => SetTrackAndLoadBandScene("Piano1");
    public void PianoMelody2() => SetTrackAndLoadBandScene("Piano2");
    public void PianoMelody3() => SetTrackAndLoadBandScene("Piano3");

    public void GuitarMelody1() => SetTrackAndLoadBandScene("Guitar1");
    public void GuitarMelody2() => SetTrackAndLoadBandScene("Guitar2");
    public void GuitarMelody3() => SetTrackAndLoadBandScene("Guitar3");

    public void DrumsMelody1() => SetTrackAndLoadBandScene("Drums1");
    public void DrumsMelody2() => SetTrackAndLoadBandScene("Drums2");
    public void DrumsMelody3() => SetTrackAndLoadBandScene("Drums3");

    public void BassMelody1() => SetTrackAndLoadBandScene("Bass1");
    public void BassMelody2() => SetTrackAndLoadBandScene("Bass2");
    public void BassMelody3() => SetTrackAndLoadBandScene("Bass3");



    private void PianoMelody1Play() => PlayMelody("Piano1", "Piano2", "Piano3");

    private void GuitarMelody1Play() => PlayMelody("Guitar1", "Guitar2", "Guitar3");

    private void DrumsMelody1Play() => PlayMelody("Drums1", "Drums2", "Drums3");

    private void BassMelody1Play() => PlayMelody("Bass1", "Bass2", "Bass3");


    private void SetTrackAndLoadBandScene(string track)
    {
        AudioListener.volume = 1;
        AudioClip clip = Resources.Load<AudioClip>(track);

        StoreSounds.noises.Add(clip);

        AudioManager.Instance.StopTestListener();
        SceneSwitcher.Instance.LoadScene("Assets/Scenes/BandScreen.unity");
    }


    private void PlayMelody(string clipName, string clipName2, string clipName3)
    {
        AudioClip clip = Resources.Load<AudioClip>(clipName);
        AudioClip clip2 = Resources.Load<AudioClip>(clipName2);
        AudioClip clip3 = Resources.Load<AudioClip>(clipName3);

        AudioManager.Instance.PlayTestListener(clip, clip2, clip3);

    }

    public void PlayAll()
    {
        if (StoreSounds.isPlaying) {
            StoreSounds.isPlaying = false;
            AudioListener.volume = 0;
            AudioManager.Instance.StopMainTrack();
        }
        else {
            StoreSounds.isPlaying = true;
            //AudioManager.Instance.UnPauseMainTrack();
            AudioListener.volume = 1;
            AudioManager.Instance.PlayMainTrack(StoreSounds.noises);
            //pauseButton.sprite = pauseButtonRender;
        };

    }

    public void Reset()
    {
        StoreSounds.noises.Clear();
        AudioManager.Instance.StopMainTrack();
        // StartCoroutine(ShowResetText()); TODO!
    }

    IEnumerator ShowResetText() // chatGPT help
    {
        resetText.gameObject.SetActive(true); // Activate the text
        resetText.text = "Game Reset!";

        // Wait for a few seconds
        yield return new WaitForSeconds(3f); // Adjust the duration as needed

        resetText.gameObject.SetActive(false); // Deactivate the text after waiting
    }

}

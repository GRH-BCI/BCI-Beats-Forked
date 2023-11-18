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
}

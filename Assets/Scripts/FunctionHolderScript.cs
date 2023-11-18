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

    public void LoadCreateMusicScene()
    {
        SceneManager.LoadScene("Assets/Scenes/CreateMusic.unity");
    }

    public void LoadBandScreenScene()
    {
        SceneManager.LoadScene("Assets/Scenes/BandScreen.unity");
    }
}

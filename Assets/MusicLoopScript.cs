using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopScript : MonoBehaviour
{
    public float BPM = 100;
    public bool isPlaying = false;

    public int beat;
    public int measure;

    private float timer;
    private float beatDuration;

    public AudioSource myAudioSource;

    // The number of the sound clip to play. 0 stands for 'none'
    public int pianoTrack = 0;
    public int guitarTrack = 0;
    public int saxophoneTrack = 0;
    public int bassTrack = 0;


    // Start is called before the first frame update
    void Start()
    {
        beat = 1;
        measure = 1;
        timer = 0.0f;

        beatDuration = 60 / BPM;

        //newBeat(1);
    }

    // Update is called once per frame
    void Update()
    {
        // Increment timer only if playing
        if (isPlaying) {
            timer += Time.deltaTime;
        }

        // Beat has finished, start a new beat
        if (timer >= beatDuration) {
            timer -= beatDuration;
            beat += 1;
            if (beat > 4) {
                measure += 1;
                beat = 1;
            }

            newBeat(beat);
            

        }
    }

    void newBeat(int beatNumber) {
        // Play a sound here
        myAudioSource.PlayOneShot(myAudioSource.clip, 1);

        pianoBeat(beat);
        guitarBeat(beat);
        saxophoneBeat(beat);
        bassBeat(beat);


    }

    void pianoBeat(int beatNumber) {

    }

    void guitarBeat(int beatNumber) {
        
    }

    void saxophoneBeat(int beatNumber) {
        
    }

    void bassBeat(int beatNumber) {
        
    }


}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MusicLoopScript : MonoBehaviour
// {
//     public float BPM = 100;
//     public bool isPlaying = false;

//     public int beat;
//     public int measure;

//     private float timer;
//     private float beatDuration;

//     public AudioSource pianoAudioSource;
//     public AudioSource guitarAudioSource;
//     public AudioSource bassAudioSource;
//     public AudioSource drumAudioSource;

//     public SpriteRenderer pauseButton;
//     public Sprite pauseButtonRender;
//     public Sprite playButtonRender;

//     // File paths for each instrument track
//     public AudioClip pianoClip1;
//     public AudioClip pianoClip2;
//     public AudioClip pianoClip3;
//     public AudioClip guitarClip1;
//     public AudioClip guitarClip2;
//     public AudioClip guitarClip3;
//     public AudioClip bassClip1;
//     public AudioClip bassClip2;
//     public AudioClip bassClip3;
//     public AudioClip drumClip1;
//     public AudioClip drumClip2;
//     public AudioClip drumClip3;


//     private AudioClip[] pianoClips;
//     private AudioClip[] guitarClips;
//     private AudioClip[] bassClips;
//     private AudioClip[] drumClips;


//     // The number of the sound clip to play. 0 stands for 'none'
//     // DEFINED IN THE STORESOUNDS SCRIPT INITIALIZED IN THE MAIN MENU
//     // public int pianoTrack = StoreSounds.pianoTrack;
//     // public int guitarTrack = StoreSounds.guitarTrack;
//     // public int bassTrack = StoreSounds.bassTrack;
//     // public int drumTrack = StoreSounds.drumTrack;
//     public int pianoTrack = 0;
//     public int guitarTrack = 0;
//     public int bassTrack = 0;
//     public int drumTrack = 0;


//     // Start is called before the first frame update
//     void Start()
//     {
//         // Delete self if a script manager object already exists
//         // check if there are any GameObjects (with the specified tag) spawned
//         if ( GameObject.FindGameObjectsWithTag("ScriptManager").Length > 1)
//         {
//             Destroy(gameObject);
//         }

//         // Set the global variables properly
//         // pianoTrack = StoreSounds.pianoTrack;
//         // guitarTrack = StoreSounds.guitarTrack;
//         // bassTrack = StoreSounds.bassTrack;
//         // drumTrack = StoreSounds.drumTrack;

//         beat = 0;
//         measure = 1;
//         timer = 0.0f;

//         beatDuration = 60 / BPM;

//         pianoClips = new AudioClip[] {null, pianoClip1, pianoClip2, pianoClip3};
//         guitarClips = new AudioClip[] {null, guitarClip1, guitarClip2, guitarClip3};
//         bassClips = new AudioClip[] {null, bassClip1, bassClip2, bassClip3};
//         drumClips = new AudioClip[] {null, drumClip1, drumClip2, drumClip3};
//         //newBeat(1);
//         DontDestroyOnLoad(gameObject);
//         //SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         pianoTrack = StoreSounds.pianoTrack;
//         guitarTrack = StoreSounds.guitarTrack;
//         bassTrack = StoreSounds.bassTrack;
//         drumTrack = StoreSounds.drumTrack;
//         isPlaying = StoreSounds.isPlaying;

//         // Increment timer only if playing
//         if (isPlaying) {
//             timer += Time.deltaTime;
//         }

//         // Beat has finished, start a new beat
//         if (timer >= beatDuration) {
//             timer -= beatDuration;
//             beat += 1;
//             if (beat > 4) {
//                 measure += 1;
//                 beat = 1;
//             }

//             newBeat(beat);
            

//         }
//     }

//     void newBeat(int beatNumber) {
//         // Play a sound here
//         //myAudioSource.PlayOneShot(pianoClips[0], 1);

//         pianoBeat(beatNumber);
//         guitarBeat(beatNumber);
//         bassBeat(beatNumber);
//         drumBeat(beatNumber);


//     }

//     void pianoBeat(int beatNumber) {
//         if (beatNumber == 1 && !pianoAudioSource.isPlaying) {
//             pianoAudioSource.PlayOneShot(pianoClips[pianoTrack], 1);
//         }
//     }

//     void guitarBeat(int beatNumber) {
//         if (beatNumber == 1 && !guitarAudioSource.isPlaying) {
//             guitarAudioSource.PlayOneShot(guitarClips[guitarTrack], 1);
//         }
//     }

//     void bassBeat(int beatNumber) {
//         if (beatNumber == 1 && !bassAudioSource.isPlaying) {
//             bassAudioSource.PlayOneShot(bassClips[bassTrack], 1);
//         }
//     }

//     void drumBeat(int beatNumber) {
//         if (beatNumber == 1 && !drumAudioSource.isPlaying) {
//             drumAudioSource.PlayOneShot(drumClips[drumTrack], 1);
//         }
//     }


//     [ContextMenu("Toggle Music")]
//     public void toggleMusic() {
//         if (isPlaying) {
//             isPlaying = false;
//             pauseButton.sprite = playButtonRender;
//         }
//         else {
//             isPlaying = true;
//             pauseButton.sprite = pauseButtonRender;
//         }
//     }


//     public void changeInstrument() {
//         SceneSwitcher.Instance.LoadScene("Assets/Scenes/ChooseInstrument.unity");
//     }


// }

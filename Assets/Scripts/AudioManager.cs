using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource testListenerSource;
    private AudioSource mainTrackSource;

    private List<AudioSource> mainTrackClips;
    private List<AudioSource> testListenerClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            testListenerSource = gameObject.AddComponent<AudioSource>();
            testListenerClips = new List<AudioSource>();

            mainTrackSource = gameObject.AddComponent<AudioSource>();
            mainTrackClips = new List<AudioSource>();
        
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopAllSounds()
    {
        AudioListener.volume = 0;
    }

    public void StopTestListener()
    {
        foreach (var source in testListenerClips)
        {
            source.Stop();
            Destroy(source);
        }
        testListenerClips.Clear();
    }

    public void StopMainTrack()
    {
        foreach (AudioSource source in mainTrackClips)
        {
            source.Stop();
            Destroy(source);
        }
        mainTrackClips.Clear();
    }




    public void PlayTestListener(AudioClip clip1, AudioClip clip2, AudioClip clip3)
    {
        EnsureTestListenerSourceExists();
        AudioListener.volume = 1;

        AudioSource audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource1.clip = clip1;
        testListenerClips.Add(audioSource1);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = clip2;
        testListenerClips.Add(audioSource2);

        AudioSource audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource3.clip = clip3;
        testListenerClips.Add(audioSource3);

        PlaySequentialClips(testListenerClips);
    }

    public void PlayMainTrack(List<AudioClip> noises)
    {
        
        foreach (AudioClip clip in noises)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            mainTrackClips.Add(audioSource);
        }

        foreach (AudioSource source in mainTrackClips)
        {
            if (source != null)
            {
                source.Play();
            }
        }
        StartCoroutine(ChangeToNotPlaying(mainTrackClips));
    }

    

    public void PauseMainTrack()
    {
        mainTrackSource.Pause(); // need to REDO!
    }

    public void UnPauseMainTrack()
    {
        mainTrackSource.UnPause(); // need to REDO!
    }




    private IEnumerator ChangeToNotPlaying(List<AudioSource> sources)
    {
        bool anyPlaying;
        do
        {
            anyPlaying = false;
            foreach (var source in sources)
            {
                if (source.isPlaying)
                {
                    anyPlaying = true;
                    break;
                }
            }
            yield return null;
        } while (anyPlaying);

        StoreSounds.isPlaying = false;
        StopMainTrack();
    }


    private void EnsureTestListenerSourceExists()
    {
        if (testListenerSource == null)
        {
            testListenerSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySequentialClips(List<AudioSource> sources)
    {
        StartCoroutine(PlayClipsSequentially(sources));
    }

    private IEnumerator PlayClipsSequentially(List<AudioSource> sources)
    {
        foreach (AudioSource source in sources)
        {
            if (source != null) {
                source.Play();
                yield return new WaitForSeconds(source.clip.length);
            }
        }
    }
}
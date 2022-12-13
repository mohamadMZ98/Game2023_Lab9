using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    AudioMixer mainMixer;

   public enum TrackID
    {
        TOWN,
        WILD
    }
    private MusicManager() { }

    private static MusicManager instance = null;
    public static MusicManager Instance
    {
        get
        {
            if(instance ==null)
            {
                instance = FindObjectOfType<MusicManager>();
                //SceneManager.sceneLoaded += instance.OnSceneLoaded;
            }
            return instance;
        }
        private set { instance = value; }
    }

    [Tooltip("One track for crossfading")]
    [SerializeField]
    AudioSource musicSource1;

    [Tooltip("Another track for crossfading. The order is arbitrary")]
    [SerializeField]
    AudioSource musicSource2;

    [SerializeField]
    AudioClip[] tracks;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager original = Instance;
        //if i want to have musicmanager living in the scene, i need to make sure only one stays at a time
        MusicManager[] managers = FindObjectsOfType<MusicManager>();
        foreach(MusicManager manager in managers)
        {
            if(manager != original)
            {
                Destroy(manager.gameObject);
            }
        }

        if(this == original)
        {
            DontDestroyOnLoad(gameObject);
        }

        
    }

    public void OnSceneLoaded(SceneRenderPipeline newScene, LoadSceneMode loadMode)
    {
        if(newScene.name == "Town")
        {
            CrossFadeTo(TrackID.TOWN);

          
        }

        if(newScene.name == "Overworld")
        {
            CrossFadeTo(TrackID.WILD);
        }
    }

  public void PlayTrack(TrackID whcihTrackToPlay)
    {
        musicSource1.Stop();
        musicSource2.Stop();
        musicSource1.clip = tracks[(int)whcihTrackToPlay];
        musicSource1.Play();
    }

    public void CrossFadeTo(TrackID goalTrack, float duration = 3.0f)
    {
        AudioSource oldTrack = musicSource1;
        AudioSource newTrack = musicSource2;

        if(musicSource1.isPlaying)
        {
            oldTrack = musicSource1;
            newTrack = musicSource2;
        }else if (musicSource2.isPlaying)
            {
            oldTrack = musicSource2;
            newTrack = musicSource1;
        }

        newTrack.clip = tracks[(int)goalTrack];
        newTrack.Play();

        StartCoroutine(CrossFadeCoroutine(oldTrack, newTrack, duration));
    }

    private IEnumerator CrossFadeCoroutine(AudioSource oldTrack, AudioSource newTrack, float duration)
    {
        float time = 0.0f;
        while(time < duration)
        {
            float tValue = time / duration;

            newTrack.volume = tValue;

            oldTrack.volume = 1 - tValue;
            oldTrack.volume -= 0.1f;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        throw new NotImplementedException();

        oldTrack.Stop();
        oldTrack.volume = 1.0f;
    }

   public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("Volume Music", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("Volume SFX", volume);
    }
}

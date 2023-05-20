using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaylistController : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup audioMixerGroup;
    [SerializeField]
    private List<AudioClip> audioClips;
    private int currentTrack = 0;
    private float playbackTime = 0.0f;
    [SerializeField]
    private bool playRandomFirstTrack = false;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixerGroup;

        playbackTime = 0.0f;
        if (playRandomFirstTrack)
        {
            currentTrack = Random.Range(0, audioClips.Count);
        }
        audioSource.clip = audioClips[currentTrack];
        audioSource.time = playbackTime;
        audioSource.Play();
    }
    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            currentTrack++;
            playbackTime = 0.0f;

            if (currentTrack >= audioClips.Count) currentTrack = 0;

            audioSource.clip = audioClips[currentTrack];
            audioSource.time = playbackTime;
            audioSource.Play();
        }
    }
    public void play()
    {
        audioSource.Play();
    }
    public void pause()
    {
        playbackTime = audioSource.time;
        audioSource.Pause();
    }
    public void reloadTrack()
    {
        audioSource.clip = audioClips[currentTrack];
        audioSource.time = playbackTime;
    }
}

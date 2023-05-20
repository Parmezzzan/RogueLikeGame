using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private bool mute = false;
    [SerializeField]
    private AudioMixerGroup audioMixerGroup;
    [SerializeField]
    private List<AudioClip> audioClips;

    private AudioSource audioSource;
    [SerializeField]
    private bool pitching = false;
    [SerializeField]
    private float pitchRange = 0.2f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixerGroup;
    }
    public void playSound()
    {
        if (pitching) audioSource.pitch = Random.Range(1.0f - pitchRange, 1.0f + pitchRange);
        if (!mute) audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
    }
}

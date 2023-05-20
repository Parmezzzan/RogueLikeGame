using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXAudioController : MonoBehaviour
{
    [SerializeField] MusicPlayer deathPlayer;
    static MusicPlayer _deathPlayer;
    [SerializeField] MusicPlayer hitPlayer;
    static MusicPlayer _hitPlayer;

    private void Awake()
    {
        _deathPlayer = deathPlayer;
        _hitPlayer = hitPlayer;
    }

    public static void PlayHit() => _hitPlayer.playSound();

    public static void PlayDeath() => _deathPlayer.playSound();
}

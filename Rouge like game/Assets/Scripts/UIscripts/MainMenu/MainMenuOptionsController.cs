using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuOptionsController : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider FXSlider;

    private string MasterName = "Master";
    private string FXName = "FX";

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        FXSlider.onValueChanged.AddListener(SetFxVolume);
    }

    private void Start()
    {
        var save = SaveManager.LoadSavefile();
        FXSlider.value = save.FXvolume;
        volumeSlider.value = save.volume;
    }
    public void OnMenuClosed()
    {
        var save = SaveManager.LoadSavefile();
        save.FXvolume = FXSlider.value;
        save.volume = volumeSlider.value;
        SaveManager.Save(save);
    }

    void SetVolume(float v) => mixer.SetFloat(MasterName, Mathf.Log10(v) * 20);
    void SetFxVolume(float v) => mixer.SetFloat(FXName, Mathf.Log10(v) * 20);
}

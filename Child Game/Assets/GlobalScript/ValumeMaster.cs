using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ValumeMaster : MonoBehaviour
{
    public string volumeParametr = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private float _volumeValue;
    private const float _multiplayer = 20f;

    public void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplayer;
        mixer.SetFloat(volumeParametr, _volumeValue);
    }

    private void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParametr, Mathf.Log10(_volumeValue) * _multiplayer);
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplayer);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParametr, _volumeValue);
    }
}

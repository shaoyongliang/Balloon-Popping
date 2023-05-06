using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeText = null;
    public GameObject VolumeCanvas;
    public GameObject PauseMenuCanvas;
    // Start is called before the first frame update

    private void Start()
    {
        LoadValues();
    }
    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
    }

    public void Save()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void Pause()
    {
        VolumeCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
    }

    public void goBack()
    {
        VolumeCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(true);
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}

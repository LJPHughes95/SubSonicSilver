using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {


    public int quality;

    public AudioMixer mixer;

    public AudioSource music;
    public Slider musicVol;

    public AudioClip[] SFX;
    public Slider SFXVol;
    public float vol;

    public Resolution[] resolutions;
    public Dropdown resolutionD;
    public Dropdown qualityD;

    public Toggle fullscreen;

    string path;
    string jsonString;

    public Options optionSave;
    //private string OSave;

    [System.Serializable]
    public class Options
    {
        public int Resolution;
        public bool Fullscreen;
        public int Quality;
        public float Music;
        public float SFX;
    }

    public void Start()
    {
        path = Application.streamingAssetsPath + "/Options.json";
        jsonString = File.ReadAllText(path);

        optionSave = JsonUtility.FromJson<Options>(jsonString);

        LoadSettings();


    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetInformation();
        }
        ChangeAudioVol(music);
        ChangeSFXVol();
    }

    public void SetResolution()
    {
        resolutionD.value = optionSave.Resolution;
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionD.options.Add(new Dropdown.OptionData(ResToString(resolutions[i])));

            resolutionD.value = i;

            resolutionD.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[resolutionD.value].width, resolutions[resolutionD.value].height, fullscreen.isOn); });
        }
        resolutionD.onValueChanged.AddListener(delegate
        {
            optionSave.Resolution = resolutionD.value;
            SaveSettings();
        });
    }

    string ResToString(Resolution res)
    {
        return res.width + "x" + res.height;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        optionSave.Fullscreen = !optionSave.Fullscreen;
        SaveSettings();
    }


    public void ChangeAudioVol(AudioSource source)
    {
        source.volume = musicVol.value;
        optionSave.Music = musicVol.value;
        SaveSettings();
    }

    public void ChangeSFXVol()
    {
        vol = SFXVol.value;
        optionSave.SFX = SFXVol.value;
        SaveSettings();
    }

    //Prints options information
    public void GetInformation()
    {
        AudioSource.PlayClipAtPoint(SFX[0], transform.position, vol);
        
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualityD.value, false);
        optionSave.Quality = QualitySettings.GetQualityLevel();
        SaveSettings();
    }

    public void SaveSettings()
    {
        string data = JsonUtility.ToJson(optionSave);
        File.WriteAllText(path, data);
    }

    public void LoadSettings()
    {
        fullscreen.isOn = optionSave.Fullscreen;
        Screen.fullScreen = fullscreen.isOn;

        musicVol.value = optionSave.Music;
        SFXVol.value = optionSave.SFX;
        qualityD.value = optionSave.Quality;
        SetResolution();
        resolutionD.value = optionSave.Resolution;
    }
}

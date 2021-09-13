using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class ConfigScene : MonoBehaviour
{
    #region resolution

    public Dropdown DropResolution;
    public Dropdown DropQuality;
    public Toggle TgWindow;

    private List<string> resolutions = new List<string>();
    private List<string> quality = new List<string>();

    void Start()
    {
        Resolution[] arrResolution = Screen.resolutions;
        foreach (Resolution r in arrResolution) {
            resolutions.Add(string.Format("{0} x {1}", r.width, r.height));
        }
        DropResolution.AddOptions(resolutions);
        DropResolution.value = (resolutions.Count - 1);

        quality = QualitySettings.names.ToList<string>();
        DropQuality.AddOptions(quality);
        DropQuality.value = QualitySettings.GetQualityLevel();
    }

    public void setWinMode() {
        if (TgWindow.isOn)
        {
            Screen.fullScreen = false;
        }
        else {
            Screen.fullScreen = true;
        }
    }

    public void setResolution() {
        String[] res = resolutions[DropResolution.value].Split('X');
        int w = Convert.ToInt16(res[0].Trim());
        int h = Convert.ToInt16(res[1].Trim());
        Screen.SetResolution(w, h, Screen.fullScreen);
    }

    public void setQuality() {
        QualitySettings.SetQualityLevel(DropQuality.value, true); 
    }

    public void Exit() {
        Application.Quit();
    }
    #endregion

    #region som
    float masterVolume;

    public void MasterVolume(float volume) {
        masterVolume = volume;
        AudioListener.volume = masterVolume;
    }

    #endregion
}

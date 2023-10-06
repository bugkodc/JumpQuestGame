using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject _Level;
    [SerializeField] public GameObject _Setting;
    [SerializeField] public GameObject _Settinggraphics;
    [SerializeField] public GameObject _Settingvolums;
    [SerializeField] public TMP_Dropdown _resDropdown;
    Resolution[] _resolutions;
    private void Start()
    {
        _resolutions= Screen.resolutions;
        _resDropdown.ClearOptions();
        List<string> _Options = new List<string>();
        int _currentResIndex = 0;
        for(int i = 0; i < _resolutions.Length; i++)
        {
            string _Option = _resolutions[i].width + " x " + _resolutions[i].height;
            _Options.Add(_Option);
            if(_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                _currentResIndex = i;
            }
        }
        _resDropdown.AddOptions(_Options);
        _resDropdown.value = _currentResIndex;
        _resDropdown.RefreshShownValue();
    }
    public void SetRes(int resIndex)
    {
        Resolution _res = _resolutions[resIndex];
        Screen.SetResolution(_res.width , _res.height, Screen.fullScreen);
    }
    public void Play()
    {
        _Level.SetActive(true);
    }
    public void Setting()
    {
        _Setting.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("can");
        Application.Quit();
    }
    public void BackLevel()
    {
        _Level.SetActive(false);
    }
    public void Backsetting()
    {
        _Setting.SetActive(false);
    }
    #region level
    public void Level1()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Tutorial 1");
    }
    public void Level3()
    {

        SceneManager.LoadScene("Tutorial 2");
    }
    #endregion
    public void SettingGraphics()
    {
        _Settinggraphics.SetActive(true);
    }
    public void BacksettingGraphics()
    {
        _Settinggraphics.SetActive(false);
    }
    public void Settingvolumes()
    {
        _Settingvolums.SetActive(true);
    }
    public void BacksettingVolumes()
    {
        _Settingvolums.SetActive(false);
    }
    public void SetGraphics(int _QualitiIndex)
    {
        QualitySettings.SetQualityLevel(_QualitiIndex);
    }
    public void ScreenFull(bool _isfullscreen)
    {
        Screen.fullScreen = _isfullscreen;
    }
}

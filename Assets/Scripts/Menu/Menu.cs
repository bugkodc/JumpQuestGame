using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject _Level;
    [SerializeField] public GameObject _Setting;
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
    public void Level1()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

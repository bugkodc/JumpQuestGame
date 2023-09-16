using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour
{
    [SerializeField] public GameObject _pausemenu;
    bool _paused = true;
    private void Update()
    {
        Inputsystem();
    }
    void Inputsystem()
    {
        if( Input.GetKeyDown(KeyCode.Escape) && _paused){
            PauseMenu();
            _paused = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !_paused)
        {
            Resume();
            _paused = true;
        }
    }
    public void PauseMenu()
    {
        _pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        _pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
    }
}

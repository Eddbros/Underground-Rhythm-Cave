using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    public void PauseButton()
    {
        Time.timeScale = 0f;
        GameObject.Find("BGM").GetComponent<AudioReverbZone>().enabled = true;
        GameObject.Find("BGM").GetComponent<AudioSource>().volume=0.4f;
        pauseBtn.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        GameObject.Find("BGM").GetComponent<AudioReverbZone>().enabled = false;
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = 1f;
        pauseBtn.SetActive(true);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);   
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        GameController.gameController.enemyStatus = true;
        ChangingScenes.instance.ReloadScene();
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        GameController.gameController.enemyStatus = true;
        ChangingScenes.instance.MainMenu();
    }

    public void OptionsButton()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);   
    }
}

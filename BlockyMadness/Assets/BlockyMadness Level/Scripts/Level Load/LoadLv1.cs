using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLv1 : MonoBehaviour
{
    public GameObject LevelSelect;
    public void LoadLV1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Levels()
    {
        LevelSelect.SetActive(true);
        Time.timeScale = 1;
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
    public void Menu()
    {
        LevelSelect.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager>
{
    public string GameName;

    public string CreditsName;

    void Awake()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    void Start()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void LoadGame()
    {
        Application.LoadLevelAsync(GameName);
    }

    public void Credits()
    {
        Application.LoadLevelAsync(CreditsName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

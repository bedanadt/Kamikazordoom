using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;

    public static bool isPaused;
    
    public GameObject pauseMenuCanvas;
    private bool Selected = false;

    public Button FirstButton;

    [SerializeField]
    private GameObject PauseButton;
    [SerializeField]
    private GameObject ResumeButton;

    // Update is called once per frame
    void Start ()
    {
#if UNITY_ANDROID
        PauseButton.SetActive(true);
        ResumeButton.SetActive(true);
#endif
    }

    void Update () {
	    if (isPaused && GameManager.PlayerIsAlive)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
            if (!Selected)
            {
                FirstButton.Select();
                Selected = true;
            }
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
            Selected = false;
        }

        if (Input.GetButtonDown("PauseButton"))
        {
            isPaused = !isPaused;
        }
	}

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.LoadLevel(mainMenu);
    }

}

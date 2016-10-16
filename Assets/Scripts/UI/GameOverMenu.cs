using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

    public string mainMenu;
        
    public GameObject GameOverMenuCanvas;
    private bool Selected = false;

    public Button FirstButton;

    // Update is called once per frame
    void Update() {
        if (!GameManager.PlayerIsAlive) {
            GameOverMenuCanvas.SetActive(true);
            Time.timeScale = 0.5f;
            AudioListener.volume = 0.5f;
            if (!Selected)
            {
                FirstButton.Select();
                Selected = true;
            }
        }
        else {
            GameOverMenuCanvas.SetActive(false);
            Selected = false;
        }
    }

    public void Restart()
    {
        Application.LoadLevel("Gameplay");
        GameManager.PlayerIsAlive = true;
    }

    public void Quit()
    {
        Application.LoadLevel(mainMenu);
    }

}

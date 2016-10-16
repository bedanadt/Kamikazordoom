using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayVideo : MonoBehaviour {
    public bool LoadLevel;
    public string LevelName;

    public string VideoName;
    // Use this for initialization
    void Start () {
        StartCoroutine("PlayVideoRoutine");
    }

    IEnumerator PlayVideoRoutine() {
        Handheld.PlayFullScreenMovie(VideoName, Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        if (LoadLevel)
        {
            GameManager.PlayerIsAlive = true;
            Application.LoadLevel(LevelName);
        }
    }
}

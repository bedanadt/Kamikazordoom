using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayVideo : MonoBehaviour {
    public bool LoadLevel;
    public string LevelName;

    public string VideoName;
#if UNITY_STANDALONE
    public MovieTexture movie;
    private AudioSource audio;
#endif
    // Use this for initialization
    void Start () {
#if UNITY_ANDROID
        StartCoroutine("PlayVideoRoutine");
#endif

#if UNITY_STANDALONE
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        StartCoroutine("PlayMyClip");
#endif
    }

#if UNITY_ANDROID
    IEnumerator PlayVideoRoutine()
    {
        Handheld.PlayFullScreenMovie(VideoName, Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        if (LoadLevel)
        {
            GameManager.PlayerIsAlive = true;
            Application.LoadLevel(LevelName);
        }
    }
#endif

#if UNITY_STANDALONE
    IEnumerator PlayMyClip()
    {
        if (!movie.isPlaying)
        {
            movie.Play();
            audio.Play();
            yield return new WaitForSeconds(movie.duration);
            if (LoadLevel)
            {
                GameManager.PlayerIsAlive = true;
                Application.LoadLevel(LevelName);
            }
        }
    }
#endif
}

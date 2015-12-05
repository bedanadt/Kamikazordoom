using UnityEngine;
using System.Collections;

public class LaserBeamCharging : MonoBehaviour {
    float Size = 0.025f;
    Vector3 Scale;

    [SerializeField]
    private GameObject Laser;

    // Use this for initialization
    void OnEnable()
    {
        transform.localScale *= 0;
        StartCoroutine("Loading");
    }

    void OnDisable()
    {
        transform.localScale *= 0;
    }

    IEnumerator Loading ()
    {
        while (transform.localScale.x < 0.7f)
        {
            Scale = new Vector3(Size, Size, 0);
            transform.localScale += Scale;
            yield return new WaitForSeconds(0.1f);
        }
        Laser.SetActive(true);
        gameObject.SetActive(false);
    }
}

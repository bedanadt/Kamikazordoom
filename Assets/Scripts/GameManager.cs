using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public float m_scrollvelocity = 3f;
    public GameObject explosion;

    private Transform transform_spawners;
    // Use this for initialization
    void Start () {
        transform_spawners = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform_spawners.Translate(new Vector3(-m_scrollvelocity, 0, 0) * Time.deltaTime);
    }
}

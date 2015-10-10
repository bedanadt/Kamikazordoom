using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    private Transform m_cameraposition;
    private Transform m_playerposition;
    public float tempolerp = 0.5f;
	// Use this for initialization

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PontoReferencia");
        m_playerposition = player.GetComponent<Transform>();
    }
	void Awake () {
        m_cameraposition = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = new Vector3(m_playerposition.position.x, 0,-10);
        m_cameraposition.position = position;

    }
}

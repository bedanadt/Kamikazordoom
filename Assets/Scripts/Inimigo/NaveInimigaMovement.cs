using UnityEngine;
using System.Collections;

public class NaveInimigaMovement : MonoBehaviour {
    public Vector2 m_speed = new Vector2(3, 3);
    public Vector2 m_direction = new Vector2(-1, 0);
    private Transform m_transform;
    private float m_Ypingpong;

    // Use this for initialization
    void Awake () {
        m_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Vector3 movement = new Vector3(m_speed.x * m_direction.x, m_speed.y * m_direction.y, 0);
        // movement *= Time.deltaTime;
        // m_transform.Translate(movement);

        m_Ypingpong = Mathf.PingPong(Time.time, 3);


        // m_transform.Translate(new Vector3(0, Mathf.PingPong(Time.time, 0.1f), 0));
        m_transform.position = new Vector3(0, (m_Ypingpong * 10), 0);
    }
}

using UnityEngine;
using System.Collections;

public class EnemyShipMovement : MonoBehaviour {

    [SerializeField]
    private float horizontal_speed = -3f;

    private float x;
    private float y;

    [SerializeField]
    private float m_velocity_sine = 2;

    [SerializeField]
    private float m_limit = 5;

    public void FixedUpdate()
    {
        y = Mathf.Sin(Time.time * m_velocity_sine);
        transform.Translate(new Vector3(horizontal_speed, y * m_limit, 0)*Time.deltaTime);

    }
}

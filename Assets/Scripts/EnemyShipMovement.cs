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
        //transform.localPosition = new Vector3(x * Time.deltaTime, y * m_limit, transform.localPosition.z);
        transform.Translate(new Vector3(horizontal_speed, y * m_limit, 0)*Time.deltaTime);

    }
}

using UnityEngine;
using System.Collections;

public class EnemyShipMovement : MonoBehaviour {

    [SerializeField]
    private float horizontal_speed = -3f;

    private float y;
    private Transform m_transform;

    [SerializeField]
    private float m_velocity_sine = 2;

    [SerializeField]
    private float m_limit = 5;

    private float PersonalTimer;

    void Awake()
    {
        m_transform = GetComponentInChildren<Transform>();
    }

    public void Update()
    {
        PersonalTimer += Time.deltaTime;
    }

    public void FixedUpdate()
    {
        y = Mathf.Sin(PersonalTimer * m_velocity_sine);
        m_transform.Translate(new Vector3(horizontal_speed, y * m_limit, 0)*Time.deltaTime);
        

    }
}

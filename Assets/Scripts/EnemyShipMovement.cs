using UnityEngine;
using System.Collections;

public class EnemyShipMovement : MonoBehaviour {
    float index;
    [SerializeField]
    private float m_velocity_sine = 2;

    [SerializeField]
    private float m_limit = 5;

    public void Update()
    {
        index += Time.deltaTime;
        float x = 0f;
        float y = Mathf.Sin(Time.time * m_velocity_sine);
        transform.localPosition = new Vector3(x, y * m_limit, 0);
    }
}

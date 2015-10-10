using UnityEngine;
using System.Collections;

public class PontoCentral : MonoBehaviour
{
    public float m_speed = 4f;
    private Transform m_transform;

    // Use this for initialization
    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_transform.Translate(m_speed*Time.deltaTime,0,0);
    }
}
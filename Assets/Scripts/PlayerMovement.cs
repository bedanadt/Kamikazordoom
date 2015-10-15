using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 speed = new Vector2(10, 10);
    public float scrollingspeed = 3f;
    private Vector2 movement;
    private Rigidbody2D m_Rigidbody;
    private Transform m_Transform;
    // Use this for initialization
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Transform = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2((speed.x * inputX) + scrollingspeed, speed.y * inputY);
    }

    void FixedUpdate()
    {

        m_Rigidbody.velocity = movement;
    }

    void OnTriggerEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Spawn")
            Debug.Log("Mah oooii");

    }
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public Vector2 speed = new Vector2(10, 10);
    public float scrollingspeed = 3f;
    public Vector2 movement;
    private Rigidbody2D m_Rigidbody;

    private float inputX;
    private float inputY;

    private CameraMovement m_Camera;

    // Use this for initialization
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        m_Camera = Camera.main.GetComponent<CameraMovement>();
        
    }

    // Update is called once per frame
    void Update() {
        #if UNITY_ANDROID
                inputX = Input.acceleration.x * 2;
                inputY = Input.acceleration.y * 2;
        #endif
        
        #if UNITY_STANDALONE
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
        #endif

        if ((transform.position.x < m_Camera.xMin && inputX < 0) || (transform.position.x > m_Camera.xMax && inputX > 0))
        {
            inputX = 0;
        }
        if ((transform.position.y < m_Camera.yMin && inputY < 0) || (transform.position.y > m_Camera.yMax && inputY > 0))
        {
            inputY = 0;
        }

        movement = new Vector2((speed.x * inputX), speed.y * inputY);
    }

    void FixedUpdate() {
        m_Rigidbody.velocity = movement;
    }
}


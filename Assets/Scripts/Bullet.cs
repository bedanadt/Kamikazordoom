using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private Rigidbody2D m_Rigidbody;
    private Transform m_Transform;
    private Vector2 direction;

    private float offsetDestroy = 2f;

    private CameraMovement CameraPositions;

    [SerializeField]
    private float force = 500;

    [SerializeField]
    private float angle = 0;


    // Use this for initialization
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        CameraPositions = Camera.main.GetComponent<CameraMovement>();

        Vector3 dir = Quaternion.AngleAxis(m_Transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.right;
        m_Rigidbody.AddForce(dir * force);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if((transform.position.x > (CameraPositions.xMax + offsetDestroy)) ||
           (transform.position.x < (CameraPositions.xMin - offsetDestroy)) ||
           (transform.position.y > (CameraPositions.yMax + offsetDestroy)) ||
           (transform.position.y < (CameraPositions.yMin - offsetDestroy)))
        {
            Destroy(gameObject);
        }
    }
}

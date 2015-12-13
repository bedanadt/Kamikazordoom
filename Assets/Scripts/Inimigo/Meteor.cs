using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {
	private float MeteorSize;

	[SerializeField]
	private float Force;

	private Rigidbody2D m_Rigidbody;
	private CameraMovement CameraPositions;

	private float rotation;
	// Use this for initialization
	void Start () {
		MeteorSize = Random.Range (1f, 2.5f);
		Force = Random.Range (300f, 500f);
		m_Rigidbody = GetComponent<Rigidbody2D>();
		CameraPositions = Camera.main.GetComponent<CameraMovement>();
		if (transform.position.y > CameraPositions.middleY) {
			rotation = Random.Range(180f, 270f);
		}
		if (transform.position.y <= CameraPositions.middleY) {
			rotation = Random.Range(90f, 180f);
		}
		transform.localScale = new Vector3(MeteorSize, MeteorSize, 1);
		Vector3 dir = Quaternion.AngleAxis(rotation, Vector3.forward) * Vector3.right;
		m_Rigidbody.AddForce(dir * Force);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

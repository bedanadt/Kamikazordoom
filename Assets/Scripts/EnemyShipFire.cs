using UnityEngine;
using System.Collections;

public class EnemyShipFire : MonoBehaviour {
    public float NextFire = 1f;
    Quaternion variavel;
    public GameObject m_Bala;

    private float NextTime = 0f;
	// Use this for initialization
	void Start () {
        NextTime = Time.time + NextFire;

        variavel = new Quaternion(transform.rotation.w, transform.rotation.x, transform.rotation.y, 1f);
	}
   
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > NextTime)
        {
            Debug.Log(transform.rotation.z);
            GameObject clone = Instantiate(m_Bala, transform.position, variavel) as GameObject;
            NextTime = Time.time + NextFire;
        }
	}
}

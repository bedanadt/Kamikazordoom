using UnityEngine;
using System.Collections;

public class EnemyShipFire : MonoBehaviour {
    public float NextFire = 1f;
    Quaternion variavel;
    public GameObject m_Bala;

    private float NextTime = 0f;
	// Use this for initialization
	void Start () {
        NextTime = Time.time + Random.Range(NextFire, NextFire+1);
	}
   
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > NextTime)
        {
            GameObject clone = Instantiate(m_Bala, transform.position, transform.rotation) as GameObject;
            NextTime = Time.time + NextFire;
        }
	}
}

using UnityEngine;
using System.Collections;

public class EnemyShipCore : MonoBehaviour {
    public float NextFire = 1f;
    Quaternion variavel;
    private float NextTime = 0f;

    private Weapon[] Arma;

    [SerializeField]
    private float horizontal_speed = -3f;
    private Transform m_transform;

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        NextTime = Time.time + Random.Range(NextFire, NextFire + 1);
    }

    void Start()
    {
        Arma = GetComponentsInChildren<Weapon>();
    }
    
    public void FixedUpdate()
    {
		m_transform.Translate(new Vector3(horizontal_speed, 0, 0)*Time.deltaTime);
        if (Time.time > NextTime)
        {
            foreach (Weapon current_weapon in Arma)
            {
                current_weapon.SendMessage("Shoot");
                NextTime = Time.time + NextFire;
            }
        }
    }
}

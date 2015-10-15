using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
    [SerializeField]
    private int m_NextEnemy = 1;
    [SerializeField]
    private int m_Enemy = 3;
    [SerializeField]
    private GameObject Inimigo;

    private int m_SpawnedEnemies = 0;
    private Transform m_Transform;
    private bool m_SpawningEnemy = false;

    private float m_ElapsedTime = 0.0f;
     
	// Use this for initialization
	void Start () {
        m_Transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if(m_SpawningEnemy)
        { 
            m_ElapsedTime += Time.deltaTime;
            if (m_ElapsedTime < m_NextEnemy)
                return;
            m_ElapsedTime = 0.0f;
            m_SpawnedEnemies++;
            if(m_SpawnedEnemies >= m_Enemy)
            {
                m_SpawningEnemy = false;
            }
        }
    }

    void OnTriggerEnter2D(Collision2D collider)
    {
        Debug.Log("Mah oooii");
//        if (collider.gameObject.tag == "Player")
//        {
//            m_SpawningEnemy = true;
//        }
    }

    void Spawn()
    {
        Instantiate(Inimigo, m_Transform.position, Quaternion.identity);
    }
}


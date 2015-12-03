using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
    [SerializeField]
    private float m_NextEnemy = 1;
    [SerializeField]
    private int m_Enemy = 3;
    [SerializeField]
    private GameObject Inimigo;

    private CameraMovement CameraPositions;
    private int m_SpawnedEnemies = 0;
    private bool m_SpawningEnemy = false;

    private float RandomY;

    private float m_ElapsedTime = 0.0f;
     
	// Use this for initialization
	void Start () {
        CameraPositions = Camera.main.GetComponent<CameraMovement>();
        RandomY = Random.Range(CameraPositions.yMin, CameraPositions.yMax);
    }
	
	// Update is called once per frame
	void Update () {
        if (CameraPositions.xMax > transform.position.x) m_SpawningEnemy = true;
        if (m_SpawningEnemy)
        {            
            m_ElapsedTime += Time.deltaTime;
            if (m_ElapsedTime < m_NextEnemy)
                return;
            m_ElapsedTime = 0.0f;
            Spawn();
            m_SpawnedEnemies++;
            if(m_SpawnedEnemies >= m_Enemy)
            {
                Destroy(gameObject);
            }
            Debug.Log(RandomY);
        }
    }

    void Spawn()
    {
        Instantiate(Inimigo, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }
}


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
    private bool generated = false;
    private float m_ElapsedTime = 0.0f;
     
	// Use this for initialization
	void Start () {
        CameraPositions = Camera.main.GetComponent<CameraMovement>();       
    }
	
	// Update is called once per frame
	void Update () {
        if (!generated)
        {
            RandomY = Random.Range(CameraPositions.yMin+1f, CameraPositions.yMax-1f);
            generated = true;
        }

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
        }
    }

    void Spawn()
    {
        Instantiate(Inimigo, new Vector3(CameraPositions.xMax, RandomY, transform.position.z), Quaternion.identity);
    }
}

using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
	[SerializeField]
	private float nextEnemyTime = 1;
	[SerializeField]
	private int enemyNumber = 3;
	[SerializeField]
	private GameObject Inimigo;

    private bool generated = false;
    private float position;

    private CameraMovement CameraPositions;
    private string EnemyName;
    
    void Start() {
        CameraPositions = Camera.main.GetComponent<CameraMovement>();
        EnemyName = Inimigo.name;
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if(generated == false && collider.gameObject.name == "Player") {
            generated = true;
            if (EnemyName == "Meteoro")
            {
                position = Mathf.Floor(Random.Range(0, 2));
                if (position == 0) StartCoroutine(Spawn(new Vector3(1, CameraPositions.yMax + 1, transform.position.z)));
                if (position == 1) StartCoroutine(Spawn(new Vector3(1, CameraPositions.yMin - 1, transform.position.z)));
            }
            else if (EnemyName == "NaveInimiga")
            {
                position = Random.Range(CameraPositions.yMin + 1f, CameraPositions.yMax - 1f);
                StartCoroutine(Spawn(new Vector3(0, position, transform.position.z)));
            }
        }
    }

    IEnumerator Spawn(Vector3 position) {
        float offCamera = position.x;
        for (int spawned = 0; spawned < enemyNumber; spawned++) {
            position.x = CameraPositions.xMax + offCamera;
            Instantiate(Inimigo, position, Quaternion.identity);
            yield return new WaitForSeconds(nextEnemyTime);
        }
        Destroy(gameObject);
    }
}
using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    private GameManager Gerenciador;
	// Use this for initialization
	void Start () {
        Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(Gerenciador.explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Gerenciador.SendMessage("EMorreu");
        }
    }
}

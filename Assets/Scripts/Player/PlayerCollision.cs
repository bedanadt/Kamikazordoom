using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private GameManager Gerenciador;
	// Use this for initialization
	void Start () {
		Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
		{
			Destroy(gameObject);
			Instantiate(Gerenciador.explosion, transform.position, transform.rotation);
			Destroy(collision.gameObject);
			Gerenciador.SendMessage("EMorreu");
		}
	}
}

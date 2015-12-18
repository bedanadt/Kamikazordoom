using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private GameManager Gerenciador;

    public bool ImortalPW = false;

    private float Timer = 0f;
	// Use this for initialization
	void Start () {
		Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Instantiate(Gerenciador.explosion, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
            if (!ImortalPW)
            {
                Destroy(gameObject);
            }
		}
    }

    void OnDestroy()
    {
        if (Gerenciador) Gerenciador.SendMessage("EMorreu");
    }
}

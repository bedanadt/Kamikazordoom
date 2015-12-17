using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private GameManager Gerenciador;

    private bool ImortalPW = false;
    private float TimeImortal = 5f;
    private float TimeImortalDisable;

    private float Timer = 0f;
	// Use this for initialization
	void Start () {
		Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    void Update()
    {
        if (ImortalPW)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeImortal)
            {
                ImortalPW = false;
                Timer = 0;
            }
        }
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
        Gerenciador.SendMessage("EMorreu");
    }

    void TriggerPowerUpBoost()
    {
        ImortalPW = true;
    }
}

using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
    public float TimeShield = 5f;
    private float VencimentoEscudo;

    private GameManager Gerenciador;
    private Transform PlayerPosition;

    [SerializeField]
    private BoxCollider2D PlayerCollider;
	// Use this for initialization
	void Start () {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
    void OnEnable() {
        VencimentoEscudo = Time.time + TimeShield;
        PlayerCollider.enabled = false;
    }

    void OnDisable()
    {
        PlayerCollider.enabled = true;
    }

	// Update is called once per frame
	void Update () {
        this.transform.position = PlayerPosition.position;
        if (Time.time >= VencimentoEscudo)
        {
            gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(Gerenciador.explosion, collision.transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;
using System.Collections;

public class LimpaTela : MonoBehaviour {
    private SpriteRenderer m_Sprite;
    private Transform m_Transform;

    public float Velocity;
    public float rotate = 25f;

    private GameManager Gerenciador;

    // Use this for initialization
    void Start()
    {
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Transform = this.transform;
        Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_Transform.transform.localScale = Vector3.zero;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 Escala = m_Transform.transform.localScale;
        Escala.x += Velocity * Time.deltaTime;
        Escala.y = Escala.x;
        Escala.z = 1;
        m_Transform.transform.localScale = Escala;

        m_Transform.Rotate(new Vector3(0, 0, rotate * Time.deltaTime));
       
        if (m_Transform.localScale.x > 35)
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        m_Transform.transform.localScale = Vector3.zero;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player")
        {
            Instantiate(Gerenciador.explosion, collider.gameObject.transform.position, transform.rotation);
            Destroy(collider.gameObject);
        }
    }
}

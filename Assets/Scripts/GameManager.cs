using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static bool PlayerIsAlive = true;

    public float m_scrollvelocity = 3f;
    public GameObject explosion;
	public Vector3 MoveFront;
	public static Transform m_PlayerMovimentacao;
	public static Transform m_CameraMovimentacao;

    private float TimeBoosted;

    private float bossState;

	private float offsetDestroy = 1f;

	private CameraMovement m_CameraPosition;

	private GameObject Boss;

    private bool playerAlive = true;
	private GameObject[] Enemy;
    private Transform transform_spawners;
    // Use this for initialization
    void Start () {
		m_CameraPosition = Camera.main.GetComponent<CameraMovement> ();
        Boss = GameObject.FindGameObjectWithTag ("Boss");
		Enemy = GameObject.FindGameObjectsWithTag ("Enemy");

		m_PlayerMovimentacao = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		m_CameraMovimentacao = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ();
        //MoveFront = new Vector3(m_scrollvelocity, 0, 0);
	}

    void Update()
    {
        if (BossReached())
        {
            m_scrollvelocity = 0f;
            Boss.GetComponent<SineMovement>().enabled = true;
            Boss.GetComponent<Core>().enabled = true;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (PlayerIsAlive)
        {
            if (m_PlayerMovimentacao) m_PlayerMovimentacao.Translate(m_scrollvelocity * Time.deltaTime, 0, 0);
            if (m_CameraMovimentacao) m_CameraMovimentacao.Translate(m_scrollvelocity * Time.deltaTime, 0, 0);
        }
    }

	void LateUpdate() {
		Enemy = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject Current in Enemy) {
			if(Current.transform.position.x < (m_CameraPosition.xMin - offsetDestroy))
			{
				Destroy(Current);
			}
		}
	}

    public bool BossReached() {
        if (m_CameraPosition.xMax > Boss.transform.position.x + 5) return true;
        else return false;
    }

    public static GameObject GetExplosion()
    {
        return (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().explosion);
    }
}

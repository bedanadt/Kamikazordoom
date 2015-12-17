﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public float m_scrollvelocity = 3f;
    public GameObject explosion;
	private Vector3 MoveFront;
	private Transform m_PlayerMovimentacao;
	private Transform m_CameraMovimentacao;

    private bool Boosted = false;
    private float BoostedSpeed = 2f;
    private float TimeBoosted;
    private float TimeBoostedOff = 5;

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
        MoveFront = new Vector3(m_scrollvelocity, 0, 0);
	}
	
    void Update()
    {
        if (Boosted && Time.time > TimeBoostedOff)
        {
            Boosted = false;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (transform_spawners) transform_spawners.Translate(new Vector3(-m_scrollvelocity, 0, 0) * Time.deltaTime);

        if (Boosted)
        {
            m_PlayerMovimentacao.Translate(MoveFront * BoostedSpeed * Time.deltaTime);
            m_CameraMovimentacao.Translate(MoveFront * BoostedSpeed * Time.deltaTime);
        }
        else
        {
            m_PlayerMovimentacao.Translate(MoveFront * Time.deltaTime);
            m_CameraMovimentacao.Translate(MoveFront * Time.deltaTime);
        }
        //if (m_EnergyBlaster) m_EnergyBlaster.Translate(MoveFront * Time.deltaTime); 
        if (!playerAlive)
        {
            Application.LoadLevel("Gameplay");
        }
		if (m_CameraPosition.xMin > Boss.transform.position.x - 15) {
			MoveFront = Vector3.zero;
			Boss.GetComponent<SineMovement>().enabled = true;
			Boss.GetComponent<Core>().enabled = true;
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

    void EMorreu()
    {
        playerAlive = false;
    }

    void BoostSpeedTrigger()
    {
        Boosted = true;
        TimeBoostedOff = Time.time + TimeBoosted;
    }

    public static GameObject GetExplosion()
    {
        return (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().explosion);
    }
}

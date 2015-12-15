using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
    private Slider m_PlayerPosition;

    private Transform Player;
    private Transform Boss;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

        m_PlayerPosition = GameObject.Find("PlayerPosition").GetComponent<Slider>();
        m_PlayerPosition.minValue = Player.transform.position.x;
        m_PlayerPosition.maxValue = Boss.transform.position.x;
        
    }
	
	// Update is called once per frame
	void Update () {
        m_PlayerPosition.value = Player.transform.position.x;
    }
}

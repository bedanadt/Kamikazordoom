using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
    private Slider m_PlayerPositionSlider;

    private Transform Player;
    private Transform Boss;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

        m_PlayerPositionSlider = GameObject.Find("PlayerPosition").GetComponent<Slider>();
        m_PlayerPositionSlider.minValue = Player.transform.position.x;
        m_PlayerPositionSlider.maxValue = Boss.transform.position.x;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Player) m_PlayerPositionSlider.value = Player.transform.position.x;
    }
}

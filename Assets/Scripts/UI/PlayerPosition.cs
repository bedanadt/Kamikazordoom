using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
    private Slider m_PlayerPositionSlider;
    private Transform Boss;
    // Use this for initialization
    void Start () {
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

        m_PlayerPositionSlider = GameObject.Find("PlayerPosition").GetComponent<Slider>();
        m_PlayerPositionSlider.minValue = GameManager.m_PlayerMovimentacao.position.x;
        m_PlayerPositionSlider.maxValue = Boss.transform.position.x;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(GameManager.m_PlayerMovimentacao) m_PlayerPositionSlider.value = GameManager.m_PlayerMovimentacao.position.x;
    }
}

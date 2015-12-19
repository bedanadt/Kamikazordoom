using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
    public static bool Boosted = false;
    private float BoostedSpeed = 2f;
    private float TimeBoosted;
    private float TimeBoostedOff = 5f;

    private float OldVelocity;

    private GameManager Gerenciador;
    private PlayerMovement m_PlayerMovement;
    private PlayerCollision Imortality;

    // Use this for initialization
    void Start () {
        Imortality = GetComponent<PlayerCollision>();
        Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
	
    void FixedUpdate()
    {
        if (Boosted)
        {
            Gerenciador.m_scrollvelocity = OldVelocity * BoostedSpeed;
            m_PlayerMovement.movement *= BoostedSpeed;
            if (Gerenciador.BossReached())
            {
                Gerenciador.m_scrollvelocity = 0;
                OldVelocity = 0;
            }
            if (Time.time > TimeBoosted)
            {
                Gerenciador.m_scrollvelocity = OldVelocity;
                Boosted = false;
                Imortality.ImortalPW = false;
            }
        }
    }

    void BoostSpeedTrigger()
    {
        OldVelocity = Gerenciador.m_scrollvelocity;
        Boosted = true;
        Imortality.ImortalPW = true;
        TimeBoosted = Time.time + TimeBoostedOff;
    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private GameObject m_Bala;

    private Slider Municao;

    [SerializeField]
    private Animator FillAnimation;

    public float fireRate = 0.1f;
    private float nextFire = 0f;

    public int totalAmmunition = 100;

    public int Ammunition;
    private bool CanShoot = true;
    private bool isShooting = false;

    [SerializeField]
    private float TimeInfinity = 3f;
    public static bool InfinityShoot = false;
    private float InfinityTimer = 0;

    private float GenericTimer = 0;

    private bool ChargingRateGenerated = false;
    private float CooldownExhaustedTime;

    public float ChargingRate = 0.05f;
    public float CooldownSimple = 0.5f;
    public float CooldownExhausted = 3f;
    private float ReloadRate = 0;

    // Use this for initialization
    void Start () {
        Municao = GameObject.Find("AmmunitionBar").GetComponent<Slider>();
        Municao.maxValue = totalAmmunition;
        Ammunition = totalAmmunition;
    }
	
	// Update is called once per frame
	void Update () {
        if (!PauseMenu.isPaused)
        {
            Municao.value = Ammunition;
            if (Input.GetButton("Fire1"))
            {
                isShooting = true;
            }
            if (isShooting && Time.time > nextFire && CanShoot && Ammunition > 0)
            {
                ChargingRateGenerated = false;
                GameObject clone = Instantiate(m_Bala, transform.position, transform.rotation) as GameObject;
                Ammunition--;
                nextFire = Time.time + fireRate;
                GenericTimer = Time.time + CooldownSimple;
                if (Ammunition == 0)
                {
                    CanShoot = false;
                    CooldownExhaustedTime = Time.time + CooldownExhausted;
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                isShooting = false;
            }
            if (!isShooting && CanShoot)
            {
                if (Time.time > GenericTimer)
                {
                    if (Time.time > ReloadRate && Ammunition <= totalAmmunition)
                    {
                        Ammunition++;
                        ReloadRate = Time.time + ChargingRate;
                    }
                }
            }
            if (!CanShoot && Time.time > CooldownExhaustedTime)
            {
                CanShoot = true;
            }
            if (InfinityShoot)
            {
                Ammunition = totalAmmunition;
                InfinityTimer += Time.deltaTime;
                if (InfinityTimer >= TimeInfinity)
                {
                    InfinityShoot = false;
                    InfinityTimer = 0;
                }
            }
        }
	}

    void UIShooting()
    {
        isShooting = true;
    }
    void UINotShooting()
    {
        isShooting = false;
    }

    void TriggerInfiniteShoot()
    {
        InfinityShoot = true;
        
    }
    
}

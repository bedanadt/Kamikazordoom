using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private GameObject m_Bala;

    public float fireRate = 0.1f;
    private float nextFire = 0f;

    public int totalAmmunition = 100;

    public int Ammunition = 100;
    private bool CanShoot = true;
    private bool isShooting = false;

    private float GenericTimer = 0;

    public float ChargingRate = 0.05f;
    public float CooldownSimple = 0.5f;
    public float CooldownExhausted = 3f;
    private float ReloadRate = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {     
	    if(Input.GetButton("Fire1") && Time.time > nextFire && CanShoot && Ammunition > 0)
        {
            isShooting = true;
            GameObject clone = Instantiate(m_Bala, transform.position, transform.rotation) as GameObject;
            Ammunition--;
            nextFire = Time.time + fireRate;
            if (CanShoot)
            {
                GenericTimer = 0f;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
        if (!isShooting)
        {
            GenericTimer += Time.deltaTime;
            if (GenericTimer > CooldownSimple)
            {
                if (GenericTimer >= ReloadRate && Ammunition <= totalAmmunition)
                {
                    Ammunition++;
                    ReloadRate = GenericTimer + ChargingRate;
                }
            }
            
            
        }
	}
}

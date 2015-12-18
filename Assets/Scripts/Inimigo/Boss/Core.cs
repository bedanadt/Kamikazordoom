using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {
    public GameObject[] Objetos;

    [SerializeField]
    private GameObject Laser;

    private bool IsShooting = false;
    private bool CDState = false;

    private int State = 0;
    private int NumberShoots = 0;

    public float ShootCD = .2f;
	// Use this for initialization
	void Start () {
        Objetos = GameObject.FindGameObjectsWithTag("BossWeapon");
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsShooting && State <= 2 && !CDState)
        {
            StartCoroutine("Atirar");
            
        }
        if (NumberShoots > 4)
        {
            State++;
            NumberShoots = 0;
            StartCoroutine("CooldownState");
            CDState = true;
        }
        if (State == 3)
        {
            CDState = true;
            Laser.SetActive(true);
            State = 4;
        }

        if (GameObject.FindGameObjectsWithTag("BossGenerator").Length == 0)
        {
            Debug.Log("You");
        }
	}

    void Reset ()
    {
        StartCoroutine("CooldownState");
        State = 0;
    }

    IEnumerator Atirar ()
    {
        IsShooting = true;
        for (int i = 0; i < Objetos.Length; i++)
        {
            Objetos[i].GetComponent<Weapon>().SendMessage("Shoot");
            yield return new WaitForSeconds(ShootCD);
        }
        IsShooting = false;
        NumberShoots++;
    }

    IEnumerator CooldownState ()
    {
        yield return new WaitForSeconds(4);
        CDState = false;
    }
}

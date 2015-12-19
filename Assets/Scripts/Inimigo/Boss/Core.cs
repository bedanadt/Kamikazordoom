using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Core : MonoBehaviour {
    public GameObject[] Objetos;

    public GameObject whitescreen;
    private Image whitescreenImage;

    [SerializeField]
    private GameObject Laser;

    private bool bossAlive = true;

    private bool IsShooting = false;
    private bool CDState = false;

    private GameManager manager;

    private int State = 0;
    private int NumberShoots = 0;

    public float ShootCD = .2f;
	// Use this for initialization
	void Start () {
        Objetos = GameObject.FindGameObjectsWithTag("BossWeapon");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        whitescreenImage = whitescreen.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!bossAlive)
        {
            StopCoroutine("Atirar");
            StopCoroutine("CooldownState");
        }
        
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
            if(bossAlive)
            {
                StartCoroutine("BossDying");
                bossAlive = false;
            }
        }
	}

    void Reset ()
    {
        StartCoroutine("CooldownState");
        State = 0;
    }

    IEnumerator Atirar ()
    {
        if (bossAlive)
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
    }

    IEnumerator CooldownState ()
    {
        yield return new WaitForSeconds(4);
        CDState = false;
    }

    IEnumerator BossDying()
    {
        whitescreen.SetActive(true);
        while (whitescreenImage.color.a < 1)
        {
            Color Novo = whitescreenImage.color;
            Novo.a += 0.1f;
            whitescreenImage.color = Novo;
            Vector3 Position = this.transform.position;
            Instantiate(manager.explosion, new Vector3(Position.x + Random.Range(-2,2), Position.y + Random.Range(-2, 2), Position.z-1), Quaternion.identity);
            yield return new WaitForSeconds(.5f);
        }
        Application.LoadLevel("Ending");
    }
}

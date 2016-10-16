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
    private bool bossAwake = false;

    private GameManager manager;

    private int State = 0;

    [SerializeField]
    private int shootTimes = 0;

    public float ShootCD = .2f;

	void Start() {
        Objetos = GameObject.FindGameObjectsWithTag("BossWeapon");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        whitescreenImage = whitescreen.GetComponent<Image>();
        bossAwake = true;
    }
	
	void Update() {
        if (bossAlive) {
            if (bossAwake) {
                StartCoroutine("CooldownState");
                bossAwake = false;
            }

            if (GameObject.FindGameObjectsWithTag("BossGenerator").Length == 0) {
                StartCoroutine("BossDying");
                bossAlive = false;
            }
        } else {
            StopCoroutine("Atirar");
            StopCoroutine("CooldownState");
        }
	}

    void Reset() {
        State = 0;
        StartCoroutine("CooldownState");
    }

    IEnumerator Atirar() {
        State++;
        for (int shoots = 0; shoots < shootTimes; shoots++) {
            for (int i = 0; i < Objetos.Length; i++) {
                Objetos[i].GetComponent<Weapon>().SendMessage("Shoot");
                yield return new WaitForSeconds(ShootCD);
            }
        }
        StartCoroutine("CooldownState");
    }

    IEnumerator CooldownState() {
        yield return new WaitForSeconds(4);
        if(State <= 1) {
            StartCoroutine("Atirar");
        } else if(State == 2) {
            Laser.SetActive(true);
        }
    }

    IEnumerator BossDying() {
        whitescreen.SetActive(true);
        while (whitescreenImage.color.a < 1) {
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

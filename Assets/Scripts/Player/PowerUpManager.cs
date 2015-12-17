using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
    public bool[] Powerup;
	// Use this for initialization

    [SerializeField]
    private GameObject EnergyBlaster;
    [SerializeField]
    private GameObject Shield;

    private GameManager Gerenciador;
    private Shoot PlayerShoot;
    private PlayerCollision PlayerCollision;

    private Image btn_LimpaTela;
    private Image btn_Escudo;
    private Image btn_TiroInfinito;
    private Image btn_Boost;

    void Start () {
        Powerup = new bool[4];
        Powerup[0] = true; //Limpa tela
        Powerup[1] = true; //Escudo
        Powerup[2] = true; //Tiro infinito
        Powerup[3] = true; //Invulnerabilidade
        
        btn_LimpaTela = GameObject.Find("btn_PowerUp_0").GetComponent<Image>();
        btn_Escudo = GameObject.Find("btn_PowerUp_1").GetComponent<Image>();
        btn_TiroInfinito = GameObject.Find("btn_PowerUp_2").GetComponent<Image>();
        btn_Boost = GameObject.Find("btn_PowerUp_3").GetComponent<Image>();

        Gerenciador = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerShoot = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<Shoot>();
        PlayerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
    }
	
	// Update is called once per frame
	void LateUpdate() {
        if(Powerup[0]) {
            Color CorPadraoA = btn_LimpaTela.color;
            CorPadraoA.a = .7f;
            btn_LimpaTela.color = CorPadraoA;
        } else {
            Color CorPadraoA = btn_LimpaTela.color;
            CorPadraoA.a = .3f;
            btn_LimpaTela.color = CorPadraoA;
        }

        if (Powerup[1]) {
            Color CorPadraoB = btn_Escudo.color;
            CorPadraoB.a = .7f;
            btn_Escudo.color = CorPadraoB;
        } else {
            Color CorPadraoB = btn_Escudo.color;
            CorPadraoB.a = .3f;
            btn_Escudo.color = CorPadraoB;
        }

        if (Powerup[2]) {
            Color CorPadraoC = btn_TiroInfinito.color;
            CorPadraoC.a = .7f;
            btn_TiroInfinito.color = CorPadraoC;
        } else  {
            Color CorPadraoC = btn_TiroInfinito.color;
            CorPadraoC.a = .3f;
            btn_TiroInfinito.color = CorPadraoC;
        }

        if (Powerup[3]) {
            Color CorPadraoD = btn_Boost.color;
            CorPadraoD.a = .7f;
            btn_Boost.color = CorPadraoD;
        } else {
            Color CorPadraoD = btn_Boost.color;
            CorPadraoD.a = .3f;
            btn_Boost.color = CorPadraoD;
        }
    }

    void TriggerLimpaTela()
    {
        if (Powerup[0])
        {
            EnergyBlaster.SetActive(true);
            Powerup[0] = false;
        }
    }

    void TriggerEscudo()
    {
        if (Powerup[1])
        {
            Shield.SetActive(true);
            Powerup[1] = false;
        }
    }

    void TriggerTiroInfinito()
    {
        if (Powerup[2])
        {
            PlayerShoot.SendMessage("TriggerInfiniteShoot");
            Powerup[2] = false;
        }
    }

    void TriggerBoost()
    {
        if (Powerup[3])
        {
            PlayerCollision.SendMessage("TriggerPowerUpBoost");
            Gerenciador.SendMessage("BoostSpeedTrigger");
            Powerup[3] = false;
        }
    }
}

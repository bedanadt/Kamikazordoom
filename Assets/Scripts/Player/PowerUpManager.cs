using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
    public bool[] Powerup;
	// Use this for initialization
    public float TempoEscudo;
    public float VelocidadeLimpaTela;
    public float TempoTiro;
    public float TempoBoost;

    private Image btn_LimpaTela;
    private Image btn_Escudo;
    private Image btn_TiroInfinito;
    private Image btn_Boost;

    void Start () {
        Powerup = new bool[4];
        Powerup[0] = false; //Limpa tela
        Powerup[1] = false; //Escudo
        Powerup[2] = false; //Tiro infinito
        Powerup[3] = false; //Invulnerabilidade
        
        btn_LimpaTela = GameObject.Find("btn_PowerUp_0").GetComponent<Image>();
        btn_Escudo = GameObject.Find("btn_PowerUp_1").GetComponent<Image>();
        btn_TiroInfinito = GameObject.Find("btn_PowerUp_2").GetComponent<Image>();
        btn_Boost = GameObject.Find("btn_PowerUp_3").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void LateUpdate() {
        Debug.Log(btn_LimpaTela.color);
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
            StartCoroutine("LimpaTela");
            Powerup[0] = false;
        }
    }

    IEnumerator LimpaTela()
    {
        yield return new WaitForSeconds(.1f);
    }

    void TriggerEscudo()
    {
        if (Powerup[1])
        {
            StartCoroutine("Escudo");
            Powerup[1] = false;
        }
    }

    IEnumerator Escudo()
    {
        yield return new WaitForSeconds(.1f);
    }

    void TriggerTiroInfinito()
    {
        if (Powerup[2])
        {
            StartCoroutine("TiroInfinito");
            Powerup[2] = false;
        }
    }

    IEnumerator TiroInfinito()
    {
        yield return new WaitForSeconds(.1f);
    }

    void TriggerBoost()
    {
        if (Powerup[3])
        {
            StartCoroutine("Boost");
            Powerup[3] = false;
        }
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(.1f);
    }
}

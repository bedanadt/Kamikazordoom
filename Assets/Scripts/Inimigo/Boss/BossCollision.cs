using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossCollision : MonoBehaviour {
    float HP = 100f;
    float BulletDMG = 10f;
    private Image m_Slider;

	// Use this for initialization
	void Start() {
        m_Slider = GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update() {
        m_Slider.fillAmount = (HP / 100);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            HP -= BulletDMG;
            Destroy(collision.gameObject);
            m_Slider.color = Color.Lerp(m_Slider.color, Color.red, 0.2f);
        }
    }
}

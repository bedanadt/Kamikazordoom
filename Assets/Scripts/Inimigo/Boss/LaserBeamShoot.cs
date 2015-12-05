using UnityEngine;
using System.Collections;

public class LaserBeamShoot : MonoBehaviour {
    public float m_Velocity = 10f;
    float rotation;
    bool subindo;

    [SerializeField]
    private GameObject Mothership;

    void OnEnable()
    {
        rotation = Random.Range(-40f, 40f);
        StartCoroutine("LaserTime");

        if (rotation > 0) subindo = true;
        else subindo = false;

        transform.eulerAngles = new Vector3(0, 0, rotation);
    }

    void FixedUpdate ()
    {
        if (subindo)
        {
            transform.eulerAngles -= new Vector3(0, 0, m_Velocity) * Time.deltaTime;
            if (transform.eulerAngles.z > 310f && transform.eulerAngles.z < 320f)
            {
                subindo = false;
            }
        }

        if (!subindo)
        {
            transform.eulerAngles += new Vector3(0, 0, m_Velocity) * Time.deltaTime;
            if (transform.eulerAngles.z > 40f && transform.eulerAngles.z < 50f)
            {
                subindo = true;
            }
        }
    }

    IEnumerator LaserTime()
    {
        yield return new WaitForSeconds(4f);
        Mothership.SendMessage("Reset");
        gameObject.SetActive(false);
    }

    
}

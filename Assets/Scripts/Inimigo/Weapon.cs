using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    [SerializeField]
    private GameObject Bullet;

    void Shoot()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}

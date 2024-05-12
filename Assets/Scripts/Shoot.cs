using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bala;
    public float fuerzaDisparo = 1000f;
    public float cooldown = 0.5f;
    private float lastShootTime = 0;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > lastShootTime && GameManager.Instance.gunAmmo>0)
            {
                GameManager.Instance.gunAmmo--;
                GameObject nuevaBala = Instantiate(bala, spawnPoint.position, spawnPoint.rotation);
                nuevaBala.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaDisparo);
                lastShootTime = Time.time + cooldown;
                Destroy(nuevaBala, 2);
            }
        }
    }


}

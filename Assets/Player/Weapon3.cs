using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon3 : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;

    AudioSource audioSource;

    public float fireForce;

  

    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void fire()
    {
        if (Weapon.bulletCount>0&&Weapon2.bulletCount>0)
        {
            GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            audioSource.Play();
        }
       
    }

}

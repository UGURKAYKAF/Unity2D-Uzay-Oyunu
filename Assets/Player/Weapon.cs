using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    /*public GameObject bullet;
    public Transform firePoint;
    AudioSource audioSource;
    [SerializeField] Text text;
    public int countBullet = 20;
    public float fireForce;
    public static int bulletCount = 20;
    
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void fire()
    {
        if (bulletCount>0)
        {
            GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            audioSource.Play();
            bulletCount--;
            text.text = string.Format("Mermi:{0}", bulletCount);
        }
        else
        {
            text.text = string.Format("Mermi Bitti");
        }
    }*/
    public GameObject bullet;
    public Transform firePoint;

    AudioSource audioSource;

    public static float fireForce=20;
    
    public static int bulletCount = 20;
    [SerializeField] Text text;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        text.text = string.Format("Mermi:{0}", bulletCount);
    }
    public void fire()
    {
        if (bulletCount > 0)
        {
            GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            audioSource.Play();
            bulletCount--;
            text.text = string.Format("Mermi:{0}", bulletCount);
        }
        else
        {
            text.text = string.Format("Mermi:Bitti");
        }
    }
}

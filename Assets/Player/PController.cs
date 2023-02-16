using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class PController : MonoBehaviour
{
    public Camera camera;

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    private Vector2 mousePosition;

    public Image healthBar;

    int countClick = 1;

    public Weapon weapon;
    public Weapon2 weapon2;
    public Weapon3 weapon3;
    

    public int karakterCan = 100;
    public int ýnýtHealth;
    

    public static int enemyCount=10;
    public static int count;
    public static int skor=0;
    public static int articakSkor;
    

   
    public Text text2;
    public Text text3;
    public Text text4;
  
    void Start()
    {
        ýnýtHealth = karakterCan;
    }

    private void Update()
    {
        healthBar.fillAmount = (float)karakterCan / (float)ýnýtHealth;    
        processInput();
        text2.text=string.Format("Öldürülen Düþman:{0}", count);
        text3.text=string.Format("Skor:{0}",skor);
        text4.text=string.Format("Eðitim Modu Düþman Hedefi : {0}",enemyCount); 
       
        if (enemyCount==10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            count = 0;
            skor = 0;
            enemyCount = 50000;
            Weapon.bulletCount = 20;
            Weapon2.bulletCount = 20;
            karakterCan = 100;
            randomSpawner.spawnNumber = 100;
        }
    }

    private void FixedUpdate()
    {
        move();
        findClosestEnemy();
    }

    void processInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        if (Input.GetMouseButtonDown(1))
        {
            weapon.fire();
            countClick++;
        }
        if (Input.GetMouseButtonDown(0))
        {
            weapon2.fire();
            countClick++;
        }
        /*if (Input.GetMouseButtonDown(2))
        {
            weapon3.fire();
        }*/
        if (countClick%5==0)
        {
            weapon3.fire();
            countClick++;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed,moveDirection.y * moveSpeed);
        
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        
        if (rb.velocity.x>0||rb.velocity.y>0||rb.velocity.x<0||rb.velocity.y<0)
        {
            Flame.move = true;
        }
        else
        {
            Flame.move = false;
        }


    }
   
    public void karakterHealth()
    {
        karakterCan -= 10;

        if (karakterCan <= 0)
        {
            Destroy(gameObject);
            randomSpawner.spawnNumber = 10;
            count = 0;
            skor = 0;
            Weapon.bulletCount = 20;
            Weapon2.bulletCount = 20;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
        
        
    }
    
    void findClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distancetoEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distancetoEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distancetoEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }
}


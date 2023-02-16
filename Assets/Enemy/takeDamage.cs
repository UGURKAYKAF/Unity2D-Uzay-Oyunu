using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class takeDamage : MonoBehaviour
{
   
    public int can = 100;
    public int maxhealt = 100;
    public int deathEnemy = 0;

    public int enemyCount = 0;
    private Renderer renderer;

    public int articakPuan;
    public static int sec;

    [SerializeField] Text text;

    //int puan = 0;
    //public int plusPuan = 1;
    private void Update()
    {
        
    }
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        PController.articakSkor = articakPuan;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            collision.GetComponent<PController>().karakterHealth();
        }
        if (collision.gameObject.tag.Equals("Bullet"))
        {

            wait();
            
        }
    }
  
   
    async void wait()
    {
        renderer.material.color = Color.red;
        await Task.Delay(100);
        renderer.material.color = Color.white;
    }
    public void health()
    {
        if (gameObject.name.Equals("Bullet 2"))
        {
            can -= 500;
        }
        else
        {
            can -= 50;
        }
         if (can <= 0)
         {
                Destroy(gameObject);
                randomSpawner.spawnNumber++;
                PController.count++;
                PController.skor += articakPuan;
                PController.enemyCount--;
         }  
    }

}

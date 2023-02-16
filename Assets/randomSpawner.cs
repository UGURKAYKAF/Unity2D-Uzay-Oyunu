using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class randomSpawner : MonoBehaviour
{
    
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefap;

    public static int spawnNumber = 30;


    public static int min;
    public static int sec;

    
    private void Update()
    {
       
        if (spawnNumber > 0)
        {
            
            int randEnemy = Random.Range(0, enemyPrefap.Length);
            int randSpawn = Random.Range(0, spawnPoints.Length);


            

            //Instantiate(enemyPrefap[randEnemy], spawnPoints[randSpawn].position,transform.rotation);

            if (sec<=15)
            {
                Instantiate(enemyPrefap[0],
               new Vector3(Random.Range(spawnPoints[randSpawn].position.x + 5, spawnPoints[randSpawn].position.x - 5),
               Random.Range(spawnPoints[randSpawn].position.y + 5, spawnPoints[randSpawn].position.y - 5)),
               transform.rotation);
                spawnNumber--;
                
            }
            else if (sec<=30)
            {
                Instantiate(enemyPrefap[Random.Range(0,2)],
               new Vector3(Random.Range(spawnPoints[randSpawn].position.x + 5, spawnPoints[randSpawn].position.x - 5),
               Random.Range(spawnPoints[randSpawn].position.y + 5, spawnPoints[randSpawn].position.y - 5)),
               transform.rotation);
                spawnNumber--;
                

            }
            else if (sec<=45)
            {
                Instantiate(enemyPrefap[Random.Range(0, 3)],
               new Vector3(Random.Range(spawnPoints[randSpawn].position.x + 5, spawnPoints[randSpawn].position.x - 5),
               Random.Range(spawnPoints[randSpawn].position.y + 5, spawnPoints[randSpawn].position.y - 5)),
               transform.rotation);
                spawnNumber--;
                
            }
            else if(sec>45)
            {
                Instantiate(enemyPrefap[randEnemy],
                new Vector3(Random.Range(spawnPoints[randSpawn].position.x + 5, spawnPoints[randSpawn].position.x - 5),
                Random.Range(spawnPoints[randSpawn].position.y + 5, spawnPoints[randSpawn].position.y - 5)),
                transform.rotation);
                spawnNumber--;
               
            }
                

            
        }
        




    }










}

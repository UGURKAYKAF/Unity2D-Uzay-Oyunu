using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{


    [SerializeField] Text text;
    public bool isCounting;
    public float timer;
    int min;
    int sec;
    private void Start()
    {
        
    }
    private void Update()
    {
        Count();
    }
    private void Count()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;
            min = Mathf.FloorToInt(timer/60f);
            sec = Mathf.FloorToInt(timer % 60f);
            randomSpawner.min = min;
            randomSpawner.sec = sec;
            takeDamage.sec = sec;
            enemyMove.sec = sec;
            Display(min, sec);

            if (sec>=0&&sec<=25)
            {
                Weapon.fireForce = 25;
                Weapon2.fireForce = 25;

                
            }
            else if (sec>25&&sec<=50)
            {
                Weapon.fireForce = 30;
                Weapon2.fireForce = 30;

               
            }
        }
    }
    private void Display(int min,int sec)
    {
        text.text = string.Format("{0}:{1}",min,sec);
    }
    public void countToggle()
    {
        isCounting = !isCounting;
    }
}

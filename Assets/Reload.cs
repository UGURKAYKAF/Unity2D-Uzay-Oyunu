using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Reload : MonoBehaviour
{
    public static int sec;
    [SerializeField] Text text;
    [SerializeField] Text text2;
    void Update()
    {
        if (PController.skor<=0)
        {
            PController.skor = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (PController.skor > 0 && Weapon.bulletCount<=19&&Weapon2.bulletCount<=19)
            {
                PController.skor -= 250;
            }
            else if(PController.skor<=0)
            {
                PController.skor = 0;
            }
            wait();
        }
        async void wait()
        {
            text.text = string.Format("Tekrardan Dolduruluyor");
            text2.text = string.Format("Tekrardan Dolduruluyor");
            await Task.Delay(1000);
            Weapon.bulletCount = 20;
            Weapon2.bulletCount = 20;
            text.text = string.Format("Mermi:{0}", Weapon.bulletCount);
            text2.text = string.Format("Mermi:{0}", Weapon2.bulletCount);
        }
    }
}

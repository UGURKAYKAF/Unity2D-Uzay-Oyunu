using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private Renderer renderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                //take damage
                collision.GetComponent<takeDamage>().health();
                Destroy(gameObject);
                break;
        }
    }
}

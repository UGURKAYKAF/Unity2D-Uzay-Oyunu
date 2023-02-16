using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;

    public static int sec;

    SpriteRenderer sprite;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        Vector3 direction = target.position - transform.position;
        //Debug.Log(direction.x);

        if (sec==15)
        {
            speed = 1.5f;
        }

        if (direction.x < 0)
        {

            sprite.flipX = false;

        }
        if (direction.x > 0)
        {
            sprite.flipX = true;
        }
    }
}

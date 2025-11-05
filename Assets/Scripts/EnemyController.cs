using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;

    private Vector2 targetPosition;
    private bool movingB;

    private void Start()
    {
        targetPosition = pointB.position;

    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //Vector2.Move komutuyla bir objeyi belirli bir pozisyona gönderebiliriz
        if (Vector2.Distance(transform.position, targetPosition) <0.1f )
        {
            if(movingB)
            {
                targetPosition=pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }

            movingB = !movingB;

            Flip(); 
        }

    }

    private void Flip()
    {
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}

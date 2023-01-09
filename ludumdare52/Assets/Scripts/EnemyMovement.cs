using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float stoppingDistance;
    private Transform target;
    public bool move;

    private bool isFacingRight;
    public SpriteRenderer sr;
    private Vector2 previousPosition;
    int movement = 0;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            move = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else 
            move = false;

        
        // Get the current position and elapsed time
        Vector2 currentPosition = transform.position;
        float elapsedTime = Time.deltaTime;

        // Calculate the movement direction along the x-axis
        if (currentPosition.x > previousPosition.x)
        {
            movement = 1;
        }
        else if (currentPosition.x < previousPosition.x)
        {
            movement = -1;
        }

        // If the x direction is not zero, print it to the console
        if (movement != 0)
        {
            Debug.Log("Movement direction: " + movement);
        }

        // Set the previous position to the current position
        previousPosition = currentPosition;
        Flip();
    }

    void Flip()
    {
        if ((movement < 0 && sr.flipX) || (movement > 0 && !sr.flipX))
        {
            sr.flipX = !sr.flipX;
        }
    }
     
}

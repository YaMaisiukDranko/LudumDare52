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
    public float horizontal;
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        horizontal = rb.velocity.x;
        Flip();
    }

    void Flip()
    {
        // Flip the sprite if the player is changing direction
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}

using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDelay = 2.0f; // delay between attacks in seconds
    public float attackDamage = 10.0f; // amount of damage dealt by each attack
    //public int damage;

    private Player _player;
    private float attackTimer = 0.0f; // timer for counting down to next attack
    private bool canAttack = false; // whether the enemy is able to attack

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime; // decrease attack timer

        if (canAttack && attackTimer <= 0.0f) // if timer is up and enemy can attack
        {
            Attack(); // attack
            attackTimer = attackDelay; // reset timer
        }
    }

    void Attack()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _player.TakeDamage(10);
        Debug.Log("Attack");
    }

    // called when the enemy's collider enters a trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // if the trigger collider is the player
        {
            canAttack = true; // enable attacking
        }
    }

    // called when the enemy's collider exits a trigger collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") // if the trigger collider is the player
        {
            canAttack = false; // disable attacking
        }
    }
}
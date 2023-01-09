using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyMovement EnemyMoveScript;
    public GameObject player;
    public int damage;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        EnemyMoveScript = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        //trig = player.GetComponentInChildren<BoxCollider2D>();
        while (!EnemyMoveScript.move && trig.CompareTag("Player"))
        {
            StartCoroutine(AttackTimer());
        }
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Attack player");
        player.GetComponent<Player>().TakeDamage(damage);
        yield return new WaitForSeconds(1);
    }


}

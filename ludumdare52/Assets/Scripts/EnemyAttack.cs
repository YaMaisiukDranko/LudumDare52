using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float stoppingDistance;
    private Transform target;
    
    public float attackRate;
    private float nextAttackTime;
    public float attackRange;
    public int damage;

    public Transform attackPoint;
    public LayerMask playerLayer;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (Time.time >= nextAttackTime)
        {
            Collider2D other = GetComponent<Collider2D>();
            if (other.CompareTag("PlayerBorder"))
            {
                Attack();
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }

    void Attack()
    {
        //anim.SetTrigger("Attack");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        target.gameObject.GetComponent<Player>().TakeDamage(damage);
        Debug.Log("Hit Player");
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

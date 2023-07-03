using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    public int damageAmount;
    public Animator playerAnim;

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                foreach (Collider2D col in enemiesToDamage)
                {
                    EnemyHealthController enemyHealth = col.GetComponent<EnemyHealthController>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.DamageEnemy(damageAmount);
                    }
                }

                foreach (Collider2D col in enemiesToDamage)
                {
                    BossHealthController bossHealth = col.GetComponent<BossHealthController>();
                    if (bossHealth != null)
                    {
                        bossHealth.TakeDamage(damageAmount);
                    }
                }
            }
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

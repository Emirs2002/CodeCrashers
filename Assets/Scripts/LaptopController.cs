using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopController : MonoBehaviour
{
    public float laptopSpeed;
    public Rigidbody2D theRB;
    public Vector2 moveDir;
    public GameObject impactEffect;
    public float blastRadius;
    public int damageAmount;
    public LayerMask whatIsDamageable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = moveDir * laptopSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

        Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, blastRadius, whatIsDamageable);

        foreach (Collider2D col in objectsToDamage)
        {
            EnemyHealthController enemyHealth = col.GetComponent<EnemyHealthController>();
            if (enemyHealth != null)
            {
                enemyHealth.DamageEnemy(damageAmount);
            }


            BossHealthController bossHealth = col.GetComponent<BossHealthController>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damageAmount);
            }

        }


    }

}

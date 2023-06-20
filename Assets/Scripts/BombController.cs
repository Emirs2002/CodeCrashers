using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeToExplode = .5f;
    public GameObject explosionPrefab;
    public float blastRadius;
    public LayerMask whatIsDestructible;
    public int damageAmount;
    public LayerMask whatIsDamageable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeToExplode -= Time.deltaTime;
        if (timeToExplode <= 0)
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);

            Collider2D[] objectsToRemove = Physics2D.OverlapCircleAll(transform.position, blastRadius, whatIsDestructible);

            if (objectsToRemove.Length > 0)
            {
                foreach (Collider2D obj in objectsToRemove)
                {
                    Destroy(obj.gameObject);
                }
            }

            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, blastRadius, whatIsDamageable);

            foreach (Collider2D col in objectsToDamage)
            {
                EnemyHealthController enemyHealth = col.GetComponent<EnemyHealthController>();
                if (enemyHealth != null)
                {
                    enemyHealth.DamageEnemy(damageAmount);
                }
            }
        }
    }
}

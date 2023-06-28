using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject karenSwarmerPrefab;
    // [SerializeField]
    // private GameObject batnarySwarmerPrefab;

    [SerializeField]
    private float karenSwarmerInterval;
    // [SerializeField]
    // private float batnarySwarmerInterval;

    public int spawnLimit;
    public bool spawn = false;

    void Start()
    {
      
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(355,388), 47, 0), Quaternion.identity);
        spawnLimit +=1;

    //limitar el numero de enemigos que van a aparecer
        if(spawnLimit <= 12)
        {
            StartCoroutine(spawnEnemy(interval,enemy));
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Player")
            {
            StartCoroutine(spawnEnemy(karenSwarmerInterval, karenSwarmerPrefab));
            }
        }
}

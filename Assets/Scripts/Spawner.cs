using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject end;

    public float waveTime = 10;
    public int currentWave = 0;
    
    [SerializeField]
    float currTime;
    [SerializeField]
    float nextWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime = Time.time;
        if (currTime > nextWave)
        {
            nextWave = currTime + waveTime;
            currentWave++;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < currentWave; i++)
        {
            GameObject currEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            currEnemy.GetComponent<EnemyAI>().goal = end;
            currEnemy.GetComponent<EnemyAI>().Health = 100 + currentWave;
            currEnemy.GetComponent<EnemyAI>().Damage = 1;
            currEnemy.transform.parent = transform;
        }


        Debug.Log("Wave " + currentWave);
    }
}

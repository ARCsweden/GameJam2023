using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSearch : MonoBehaviour
{

    public float turretTargetRadius = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EnemyHealth GetBestTarget(){
        //Finds all enemies in reach
        List<EnemyHealth> enemies = new List<EnemyHealth>();
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position,turretTargetRadius,LayerMask.GetMask("Default"),QueryTriggerInteraction.Collide);
        foreach(Collider col in colliders){
            EnemyHealth enemy;
            if(col.TryGetComponent<EnemyHealth>(out enemy)){
                enemies.Add(enemy);
            }
        }
        //Outputs first found enemy
        if(enemies.Count > 0){
            return enemies[0];
        }
        return null;


    }
}

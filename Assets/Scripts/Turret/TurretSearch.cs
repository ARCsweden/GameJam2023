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

    public EnemyAI GetBestTarget(){
        //Finds all enemies in reach
        List<EnemyAI> enemies = new List<EnemyAI>();
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position,turretTargetRadius,LayerMask.GetMask("Default","NonCollision"),QueryTriggerInteraction.Collide);
        foreach(Collider col in colliders){
            EnemyAI enemy;
            if(col.TryGetComponent<EnemyAI>(out enemy)){
                enemies.Add(enemy);
            }
        }
        //Outputs first found enemy
        if(enemies.Count > 0){
            int closestIndex = 0;
            float closest = float.MaxValue;
            for (int i = 0; i < enemies.Count; i++)
            {
                float distance = Vector3.Distance(enemies[0].gameObject.transform.position,transform.position);
                if(distance < closest){
                    closest = distance;
                    closestIndex = i;
                }
            }
            return enemies[closestIndex];
        }
        return null;


    }
}

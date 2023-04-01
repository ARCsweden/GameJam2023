using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TurretSearch))]
[RequireComponent(typeof(TurretShooter))]
public class TurretAim : MonoBehaviour
{
    public EnemyHealth target;
    private TurretSearch turretSearcher;
    private TurretShooter turretShooter;
    private void Start(){
        turretSearcher = GetComponent<TurretSearch>();
        turretShooter = GetComponent<TurretShooter>();
    }

    private void Update(){
        //Check if target needs to be updated
        if(target == null){
            target = turretSearcher.GetBestTarget();
            return;
        }
        if(Vector3.Distance(gameObject.transform.position,target.transform.position) > turretSearcher.turretTargetRadius){
            target = turretSearcher.GetBestTarget();
            return;
        }

        //Aim towards target
        transform.LookAt(target.gameObject.transform);
        //If looking at target
        if(turretShooter.cooldown <= 0)
            turretShooter.Shoot(target);
    }
}

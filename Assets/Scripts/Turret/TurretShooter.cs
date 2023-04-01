using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField]
    private float fullCooldown = 1;
    public float cooldown = 0;
    public Transform shootPoint;
    public LineRenderer laserLine;
    public void Update (){
        cooldown -= Time.deltaTime;
    }
    public void Shoot(EnemyHealth target)
    {
        RaycastHit raycastHit;
        cooldown = fullCooldown;
        if(Physics.Linecast(shootPoint.position,target.transform.position, out raycastHit,LayerMask.GetMask("Default"),QueryTriggerInteraction.Ignore)){
            EnemyHealth enemy;
            if(raycastHit.collider.TryGetComponent<EnemyHealth>(out enemy)){
                enemy.hp -= 10;
            }
            laserLine.SetPosition(1,new Vector3(0,0,raycastHit.distance));
            laserLine.enabled = true;
            StartCoroutine("TurnOffLaserAfterTime",0.1f);
        }
    }

    IEnumerator TurnOffLaserAfterTime(float laserTime){
         yield return new WaitForSeconds(laserTime);
         laserLine.enabled = false;
    }
}

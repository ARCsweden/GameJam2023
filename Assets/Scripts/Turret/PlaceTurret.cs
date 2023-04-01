using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTurret : MonoBehaviour
{
    private GameObject placeHolder;
    public GameObject placeHolderCorrect;
    public GameObject placeHolderObscured;

    private BoxCollider placeHolderCol;
    public GameObject turretPrefab;
    // Start is called before the first frame update
    void Start()
    {
        placeHolder = placeHolderCorrect;
        placeHolderCol = placeHolder.GetComponent<BoxCollider>();

    }

    private bool placing = false;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(placing == false){
                placing = true;
                placeHolder.SetActive(true);
                return;
            }
            else{
                placeHolder.SetActive(false);
                placing = false;
            }
        }
        
        RaycastHit rhit;
        bool foundGround = Physics.Raycast(transform.position + Vector3.up * 10,Vector3.down, out rhit,13,LayerMask.GetMask("PlaceableGround"));
        Collider[] colliders = Physics.OverlapBox(placeHolder.transform.position + placeHolderCol.center,placeHolderCol.size/2,placeHolder.transform.rotation,LayerMask.GetMask("Default"),QueryTriggerInteraction.Ignore);
        if(foundGround){
                //placeHolderCorrect.transform.position = Vector3.MoveTowards(placeHolder.transform.position,rhit.point,Vector3.Distance(placeHolder.transform.position,rhit.point)*50*Time.deltaTime);
                //placeHolderObscured.transform.position = Vector3.MoveTowards(placeHolder.transform.position,rhit.point,Vector3.Distance(placeHolder.transform.position,rhit.point)*50*Time.deltaTime);
                placeHolderCorrect.transform.position = new Vector3(placeHolderCorrect.transform.position.x, rhit.point.y, placeHolderCorrect.transform.position.z);
                placeHolderObscured.transform.position = new Vector3(placeHolderObscured.transform.position.x, rhit.point.y, placeHolderObscured.transform.position.z);

        }

        if(placing && Input.GetButton("Fire1") && foundGround && colliders.Length == 0){
            Instantiate(turretPrefab,placeHolder.transform.position,placeHolder.transform.rotation);
            placeHolder.SetActive(false);
            placing = false;
        }
        if(!foundGround || colliders.Length > 0){
            bool active = placeHolder.activeSelf;
            placeHolderCorrect.SetActive(false);
            placeHolder = placeHolderObscured;
            placeHolder.SetActive(active);
        }
        else{
            bool active = placeHolder.activeSelf;
            placeHolderObscured.SetActive(false);
            placeHolder = placeHolderCorrect;
            placeHolder.SetActive(active);
        }
    }
}

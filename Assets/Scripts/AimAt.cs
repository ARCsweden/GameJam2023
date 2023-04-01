using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAt : MonoBehaviour
{
    public GameObject toolBase;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(toolBase.transform.GetChild(0));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTo : MonoBehaviour
{
    public GameObject toolBase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, toolBase.transform.GetChild(0).position);
    }
}


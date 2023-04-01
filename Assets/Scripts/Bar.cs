using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    Vector3 size;
    Vector3 baseSize;
    public float test;

    // Start is called before the first frame update
    void Start()
    {
        baseSize = gameObject.transform.localScale;
        size = baseSize;
    }


    // Update is called once per frame
    void Update()
    {
        Rezise(test);
    }

    public void Rezise(float change)
    {
        if(change <= 0)
        {
            change = 0.01f;
        }

        size.x = baseSize.x * change;
        gameObject.transform.localScale = size;
    }
}

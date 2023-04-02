using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public int max = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change(int value)
    {
        if(value > max)
        {
            value = max;
        }

        gameObject.GetComponent<TMPro.TextMeshPro>().text = value.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should be updated with how many turrets are left

public class Left : MonoBehaviour
{
    int maxNumber;

    // Start is called before the first frame update
    void Start()
    {
        maxNumber = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change(int value)
    {

        if(value > maxNumber)
        {
            value = maxNumber; 
        }

        for (int i = 0; i < value; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = value; i < maxNumber; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}

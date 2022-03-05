using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProBuilder2.Common;
public class triggerLight : MonoBehaviour
{
    Color col = new Color(0f, .7f, 1f, 1f);
    public lightControl control;
    public float x;
    public float y;
    private void OnTriggerEnter(Collider other)
    {

        
            
            StartCoroutine(control.HttpPutLight(1f, 1f, 1f, 255));
            

           

    }

    private void OnTriggerExit(Collider other)
    {
        
        //bri is between 0 - 255
        StartCoroutine(control.HttpPutLight(1f, 0.5f, 0.5f, 255));
        
    }
}

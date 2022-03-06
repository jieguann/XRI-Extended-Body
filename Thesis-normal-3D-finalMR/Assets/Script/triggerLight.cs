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
    public bool TriggerFlag;

    void Start()
    {
        TriggerFlag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TriggerFlag == true)
        {
             StartCoroutine(control.HttpPutLight(1f, 1f, 1f, 255)); 
        }
        TriggerFlag = false;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (TriggerFlag == false)
        {
            //bri is between 0 - 255
            StartCoroutine(control.HttpPutLight(1f, 1f, 0.5f, 0));
        }
        TriggerFlag = true;
    }
}

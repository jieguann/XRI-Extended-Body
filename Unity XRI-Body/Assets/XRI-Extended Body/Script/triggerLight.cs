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
    

    private Coroutine turnOnLight;
    private Coroutine turnOffLight;

    public bool flag;
    void Start()
    {
        flag = false;
        turnOffLight = StartCoroutine(control.HttpPutLight(1f, 1f, 0.5f, 0, false));

        StopCoroutine(turnOffLight);

    }


    public void triggerLighting()
    {
        flag = !flag;
        if (flag == true)
        {
            
                turnOnLight = StartCoroutine(control.HttpPutLight(1f, 1f, 1f, 255, true));
                StopCoroutine(turnOnLight);
                Debug.Log("true");
                
            
        }

        if (flag == false)
        {
            
                //bri is between 0 - 255
                turnOffLight = StartCoroutine(control.HttpPutLight(1f, 1f, 0.5f, 0, false));

                StopCoroutine(turnOffLight);

            Debug.Log("false");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(flag == true)
        {
            if (other.tag == "bulb")
            {
                turnOnLight = StartCoroutine(control.HttpPutLight(1f, 1f, 1f, 255, true));
                StopCoroutine(turnOnLight);
                flag = false;            
            }
        }
        

        

        
    }

    private void OnTriggerExit(Collider other)
    {
        if(flag == false)
        {
            if (other.tag == "bulb")
            {
                //bri is between 0 - 255
                turnOffLight = StartCoroutine(control.HttpPutLight(1f, 1f, 0.5f, 0, false));

                StopCoroutine(turnOffLight);
                flag = true;
            }
        }
       
    }
}

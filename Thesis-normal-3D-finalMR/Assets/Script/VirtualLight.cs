using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualLight : MonoBehaviour
{
    private bool flag;
    [SerializeField] private Light virtualLight;
    void Start()
    {
        flag = false;
    }
    public void triggerLighting()
    {
        flag = !flag;
        if (flag == true)
        {

            virtualLight.intensity = 30;


        }

        if (flag == false)
        {

            virtualLight.intensity = 1;
        }
    }
}

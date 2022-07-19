using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;
public class VirtualLight : MonoBehaviour
{
    private bool flag;
    [SerializeField] private Light virtualLight;
    [SerializeField] private VolumetricLightBeam lightBean;
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
            lightBean.intensityGlobal = 1;


        }

        if (flag == false)
        {

            virtualLight.intensity = 0.1f;
            lightBean.intensityGlobal = 0;
        }
    }
}

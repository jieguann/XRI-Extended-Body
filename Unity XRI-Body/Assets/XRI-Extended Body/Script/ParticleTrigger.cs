using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;
public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] private Light pointLight;
    [SerializeField] private Light spotLight;
    [SerializeField] private VolumetricLightBeam lightBean;
    ParticleSystem ps;
    private Coroutine colorChangLight;
    public lightControl control;
    public triggerLight trigger;
    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        

        // iterate through the particles which entered the trigger and make them red
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            //p.startColor = new Color32(255, 0, 0, 255);
            //enter[i] = p;

            Debug.Log(p.startColor);
            pointLight.color = p.startColor;
            spotLight.color = p.startColor;
            lightBean.color = p.startColor;
            //light control
            if (trigger.flag == true) {
                colorChangLight = StartCoroutine(control.HttpPutLight(p.startColor.r, p.startColor.g, p.startColor.b, p.startColor.a, true));

                StopCoroutine(colorChangLight);
            }
            
        }
        //Debug.Log("trigger");


        // re-assign the modified particles back into the particle system
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        
    }
}

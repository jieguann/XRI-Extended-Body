using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalControl : MonoBehaviour
{
    [SerializeField] private M2MqttUnity.Examples.MQTTTest MQTT;
    public ParticleSystem fire;
    public ParticleSystem water;
    public ParticleSystem spary;
    
    // Start is called before the first frame update
    void Start()
    {
        fire.Stop();
        water.Stop();
        spary.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        particelPlay(MQTT.teddyBear, spary);
        particelPlay(MQTT.wineGlass, water);
        particelPlay(MQTT.cellPhone, fire);
    }


    void particelPlay(bool flag, ParticleSystem System)
    {
        bool localflag = true;
        if (flag == true && localflag ==true)
        {
            System.Play();
            localflag = false;
        }
        else { 
            System.Stop();
            localflag = true;
        }
    }
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
using CI.HttpClient;
using ProBuilder2.Common;
public class lightControl : MonoBehaviour
{
    public string ipAddress;
    public string hueAddress;
    [Serializable]
    public class LightJson
    {
        public int bri;
        public float[] xy;
        public bool on;

    }
    LightJson lightValue = new LightJson();
    //public ColorPicker picker;

    void Start()
    {
        lightValue.xy = new float[2];

    }

    //Access this for other to control light
    public IEnumerator HttpPutLight(float r, float g, float b, int bri,bool on)
    {   //picker.GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;
        Color col = new Color(r, g, b, 1);
        pb_XYZ_Color xyz = pb_XYZ_Color.FromRGB(col);
        pb_CIE_Lab_Color lab = pb_CIE_Lab_Color.FromXYZ(xyz);
        //Calculate the xy values from the XYZ values

        //float x = X / (X + Y + Z); float y = Y / (X + Y + Z);
        //https://github.com/johnciech/PhilipsHueSDK/blob/master/ApplicationDesignNotes/RGB%20to%20xy%20Color%20conversion.md
        float x = xyz.x / (xyz.x + xyz.y + xyz.z);
        float y = xyz.y / (xyz.x + xyz.y + xyz.z);
        //b =  true;


        lightValue.xy[0] = x;
        lightValue.xy[1] = y;
        lightValue.bri = bri;
        lightValue.on = on;
        updateLight();
        //picker.b = false;

        yield return null;
    }

    private void updateLight()
    {
        //httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/4/state");
        httpPostLight("http://" + ipAddress + "/api/" +hueAddress+ "/lights/4/state");
        httpPostLight("http://" + ipAddress + "/api/" + hueAddress + "/lights/3/state");
        httpPostLight("http://" + ipAddress + "/api/" + hueAddress + "/lights/2/state");
        httpPostLight("http://" + ipAddress + "/api/" + hueAddress + "/lights/1/state");
        //httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/3/state");
        //httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/2/state");
        //httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/1/state");
        /*
        var client = new HttpClient();
        client.Post(new Uri("https://maker.ifttt.com/trigger/toggleLight/json/with/key/mSl1498NtCACZrYh8eAbtz9ZgfAdFtowYUZPsDmyPhb"), null,
            HttpCompletionOption.AllResponseContent, r =>
            {   // This callback is raised when the request completes
                if (r.IsSuccessStatusCode)
                {    // Read the response content as a string if the server returned a success status code
                    string responseData = r.ReadAsString();
                    //print(responseData);
                }
            }); 
         */


    }

    private void httpPostLight(string url)
    {
        var client = new HttpClient();
        string json = JsonUtility.ToJson(lightValue);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        client.Put(new Uri(url), content, HttpCompletionOption.AllResponseContent, r =>
        {   // This callback is raised when the request completes
            if (r.IsSuccessStatusCode)
            {    // Read the response content as a string if the server returned a success status code
                string responseData = r.ReadAsString();
                //print(responseData);
            }
        });
    }
}

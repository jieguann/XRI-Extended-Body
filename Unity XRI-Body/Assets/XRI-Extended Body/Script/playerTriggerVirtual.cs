using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerVirtual : MonoBehaviour
{
    public GameManager gameManaer;
    public float distance;
    public bool distanceFlag;
    private Vector3 origitanPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        distanceFlag = true;
        origitanPlayerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameManaer.MRSpace.transform.position, transform.position);


        if (distanceFlag == true)
        {


            gameManaer.transparentValue = map(distance, 1.45f,1.5f,1,0);
            //gameManaer.transparentValue = Vector3.Lerp(origitanPlayerPosition, gameManaer.MRSpace.transform.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player")
        {
            gameManaer.skyboxGlalaxyFlag = true;
            gameManaer.planetsFlag = true;
            gameManaer.transparentValue = 1.5f;
            distanceFlag = false;
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManaer.skyboxGlalaxyFlag = false;
            gameManaer.planetsFlag = false;
            gameManaer.transparentValue = 0;
            distanceFlag = true;
        }

    }


    // Maps a value from ome arbitrary range to another arbitrary range
    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}

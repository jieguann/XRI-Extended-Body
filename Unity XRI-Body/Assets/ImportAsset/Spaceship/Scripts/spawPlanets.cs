using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawPlanets : MonoBehaviour
{    public List<GameObject> planets = new List<GameObject>();
    public GameObject planetPrefab;

    [SerializeField] BoxCollider bc;
    Vector3 cubeSize;
    Vector3 cubeCenter;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        

    // Update is called once per frame
    void Update()
    {
        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
                planets.Add(Instantiate(planetPrefab, GetRandomPosition(), Quaternion.identity, transform));

                Timer = 2f;
        }


        for(int i=0; i < planets.Count; i++)
        {
            planets[i].transform.position -= transform.forward * 10f * Time.deltaTime;
            if (planets[i].transform.position.z < -200f)
            {
                Destroy(planets[i]);
                planets.Remove(planets[i]);
            }
        }
        /*
        foreach (GameObject planet in planets)
        {
            planet.transform.position -= transform.forward * 10f * Time.deltaTime;
            if(planet.transform.position.z < -200f)
            {
                Destroy(planet);
                planets.Remove(planet);
            }
        }
        */
    }


    


    private Vector3 GetRandomPosition()
    {
        // You can also take off half the bounds of the thing you want in the box, so it doesn't extend outside.
        // Right now, the center of the prefab could be right on the extents of the box
        Vector3 randomPosition = new Vector3(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2));

        return cubeCenter + randomPosition;
    }
}

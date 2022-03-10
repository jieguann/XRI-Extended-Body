using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform landingSpot;
    public bool hasLanded;
    //public string landingButton;
    public bool inLandingZone;
    public bool onLanding;


    public Transform player;
    public GameManager gameManager;
    private Coroutine landingCoroutine;
    // Start is called before the first frame update
    public GameObject[] planetPrefeb;
    public GameObject planetObject;


    int indexPlanet;

    public lightControl control;
    private bool flag;
    private Coroutine turnOnLight;
    Color col;

    void Start()

    {
        landingSpot = GetComponentInParent<Transform>();
        control = GameObject.FindWithTag("lightTrigger").GetComponent<lightControl>();
        player = GameObject.FindWithTag("Player").transform;
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
        Random.seed = (int)System.DateTime.Now.Ticks;
        indexPlanet = Random.Range(0, planetPrefeb.Length);
        planetObject = Instantiate(planetPrefeb[indexPlanet], transform);
        col = planetObject.GetComponent<Renderer>().material.color;
        //print(planetPrefeb.Length - 1);

        flag = true;
        onLanding = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown(landingButton) && inLandingZone == true)
        if (inLandingZone == true && onLanding == true)
        {
            if(hasLanded == false)
            {

                //get ship to land
                landingCoroutine = StartCoroutine(land());
                hasLanded = true;
                onLanding = false;

            }
            else
            {
                //get ship out
                hasLanded = false;
                StopCoroutine(landingCoroutine);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inLandingZone = true;


            if (flag == true)
            {
                
                    turnOnLight = StartCoroutine(control.HttpPutLight(col.r, col.g, col.b, 255, true));
                    StopCoroutine(turnOnLight);
                    flag = false;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inLandingZone = false;
            flag = true;
            onLanding = true;

        }
    }

    IEnumerator land()
    {
        while (Vector3.Distance(player.position, landingSpot.position) > 0.5f)
        {
            landingSpot.position = Vector3.MoveTowards(landingSpot.position, player.position, gameManager.spaceshipMovementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}

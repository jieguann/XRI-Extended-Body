using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform landingSpot;
    public bool hasLanded;
    public string landingButton;
    public bool inLandingZone;
    public Transform player;
    public GameManager gameManager;
    private Coroutine landingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown(landingButton) && inLandingZone == true)
        if (inLandingZone == true && hasLanded == false)
        {
            if(hasLanded == false)
            {

                //get ship to land
                landingCoroutine = StartCoroutine(land());
                hasLanded = true;

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inLandingZone = false;
        }
    }

    IEnumerator land()
    {
        while (Vector3.Distance(player.position, landingSpot.position) > 0.5f)
        {
            player.position = Vector3.MoveTowards(player.position, landingSpot.position, gameManager.spaceshipMovementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}

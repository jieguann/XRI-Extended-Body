using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public Animator anim;
    public string gripButton;
    private GraableObject hoveredObject;
    private GraableObject grabObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(gripButton))
        {
            GripStart();
            if(hoveredObject != null)
            {
                grabObject = hoveredObject;
                grabObject.OnGrabStart(this);
                hoveredObject = null;
            }
        }

        if (Input.GetButtonUp(gripButton))
        {
            Release();
            if (grabObject != null)
            {
                grabObject.OnGrabEnd();
                grabObject = null;
            }
        }


    }

    void GripStart()
    {
        anim.SetBool("Gripped", true);
    }

    void Release()
    {
        anim.SetBool("Gripped", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        var grabable = other.GetComponent<GraableObject>();
        if (grabable != null)
        {
            hoveredObject = grabable;
            hoveredObject.OnHoverStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var grabable = other.GetComponent<GraableObject>();
        if (grabable != null && hoveredObject!=null)
        {
            hoveredObject.OnHoverEnd();
            hoveredObject = null;
            
        }
    }
}

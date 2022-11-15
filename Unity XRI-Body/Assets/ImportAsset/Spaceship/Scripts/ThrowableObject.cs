using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : GraableObject
{
    public float shootForce;

    public bool offsetGrab = true;

    private Grabber tempHand;
    private FixedJoint joint;
    private Vector3 previousPosition;

    private Queue<Vector3> previousVelocities = new Queue<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnHoverStart()
    {
        //base.OnHoverStart();
    }

    public override void OnHoverEnd()
    {
        //base.OnHoverEnd();
    }

    public override void OnGrabStart(Grabber hand)
    {
        if (!offsetGrab)
        {
            transform.position = hand.transform.position;
            transform.rotation = hand.transform.rotation;
        }
        //base.OnGrabStart(hand);
        //tempHand = hand;
        joint = gameObject.AddComponent<FixedJoint>();
        //joint = gameObject.GetComponent<FixedJoint>
        joint.connectedBody = hand.GetComponent<Rigidbody>();
    }
    public override void OnGrabEnd()
    {
        //base.OnGrabEnd();
        //Shooting and this is temp
        //transform.SetParent
        //GetComponent<Rigidbody>().AddForce(tempHand.transform.forward*shootForce);
        //tempHand = null;
        if(joint != null)
        {
            Destroy(joint);

            //Calculate the velocity
            var averageVelocity = Vector3.zero;
            foreach (var velocity in previousVelocities)
            {
                averageVelocity += velocity;
            }
            averageVelocity /= previousVelocities.Count;
            //apply the velocity
            GetComponent<Rigidbody>().velocity = averageVelocity * shootForce;
        }
        
    }

    private void FixedUpdate()
    {
        //caculate a single velocity

        var velocity = transform.position - previousPosition;

        //rememberr the current position to be used in the next iteration
        previousPosition = transform.position;

        // Add the calculated velocity into our queue
        previousVelocities.Enqueue(velocity);

        //if the size of the quque is greater than a sample size, then remove the first one
        if(previousVelocities.Count > 20)
        {
            previousVelocities.Dequeue();
        }
        

    }
}

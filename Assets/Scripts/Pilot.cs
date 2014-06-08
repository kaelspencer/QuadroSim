using UnityEngine;
using System.Collections;

public class Pilot : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Debug.Log("Starting up.");
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(Physics.gravity * -1);

        if (Input.GetKey("up"))
        {
            rigidbody.AddForce(new Vector3(0, 1, 0) * 10);
        }

        if (Input.GetKey("down"))
        {
            rigidbody.AddForce(new Vector3(0, 1, 0) * -1 * 10);
        }

        if (Input.GetKey("w"))
        {
            rigidbody.AddTorque(new Vector3(1, 0, 0) * 0.1f);
        }

        if (Input.GetKey("s"))
        {
            rigidbody.AddTorque(new Vector3(1, 0, 0) * -1 * 0.1f);
        }

        if (Input.GetKey("a"))
        {
            rigidbody.AddTorque(new Vector3(0, 0, 1) * 0.1f);
        }

        if (Input.GetKey("d"))
        {
            rigidbody.AddTorque(new Vector3(0, 0, 1) * -1 * 0.1f);
        }


        // Counteract rotations.
        if (Input.GetKey("space"))
        {
            // TODO: Why not rigidbody.sleepAngularVelocity?
            if (rigidbody.angularVelocity.magnitude > 0.001f)
            {
                rigidbody.AddTorque(rigidbody.angularVelocity * -1 * 0.1f);
            }
        }
    }
}

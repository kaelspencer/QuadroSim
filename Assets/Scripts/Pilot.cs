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
        bool rotationalInput = false;

        if (Input.GetKey("up"))
        {
            rigidbody.AddForce(transform.up * 20);
        }

        if (Input.GetKey("w"))
        {
            rotationalInput = true;
            rigidbody.AddTorque(new Vector3(1, 0, 0) * 0.1f);
        }

        if (Input.GetKey("s"))
        {
            rotationalInput = true;
            rigidbody.AddTorque(new Vector3(1, 0, 0) * -1 * 0.1f);
        }

        if (Input.GetKey("a"))
        {
            rotationalInput = true;
            rigidbody.AddTorque(new Vector3(0, 0, 1) * 0.1f);
        }

        if (Input.GetKey("d"))
        {
            rotationalInput = true;
            rigidbody.AddTorque(new Vector3(0, 0, 1) * -1 * 0.1f);
        }


        // Counteract rotations.
        if (!rotationalInput)
        {
            // TODO: Why not rigidbody.sleepAngularVelocity?
            if (rigidbody.angularVelocity.magnitude > 0.001f)
            {
                rigidbody.AddTorque(rigidbody.angularVelocity * -1 * 0.1f);
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using System;

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

        rigidbody.AddForce(transform.up * 15 * Input.GetAxis("Vertical"));
        rigidbody.AddTorque(new Vector3(1, 0, 0) * -0.05f * Input.GetAxis("RotationX"));
        rigidbody.AddTorque(new Vector3(0, 0, 1) * 0.05f * Input.GetAxis("RotationZ"));

        if (Math.Abs(Input.GetAxis("RotationX")) > 0.01f || Math.Abs(Input.GetAxis("RotationZ")) > 0.01f)
        {
            rotationalInput = true;
        }

        // Counteract rotations.
        if (!rotationalInput && (Math.Abs(transform.up.x) > 0.01f || Math.Abs(transform.up.y) < 0.99f || Math.Abs(transform.up.z) > 0.01f))
        {
            Vector3 torque = new Vector3();

            // Rotate about X, XY plane.
            if (transform.up.z > 0 && rigidbody.angularVelocity.x > 0)
            {
                torque.x = -100 * (1 - transform.up.y);
            }
            else if (transform.up.z < 0 && rigidbody.angularVelocity.x < 0)
            {
                torque.x = 100 * (1 - transform.up.y);
            }

            // Rotate about Z, YZ plane.
            if (transform.up.x > 0 && rigidbody.angularVelocity.z < 0)
            {
                torque.z = 100 * (1 - transform.up.y);
            }
            else if (transform.up.x < 0 && rigidbody.angularVelocity.z > 0)
            {
                torque.z = -100 * (1 - transform.up.y);
            }

            if (torque.magnitude > 0)
            {
                rigidbody.AddTorque(torque);
            }
        }
    }
}

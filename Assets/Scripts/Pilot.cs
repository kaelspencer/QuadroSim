using UnityEngine;
using System.Collections;
using System;

public class Pilot : MonoBehaviour
{
    void Update()
    {
        float x = -90.0f * Input.GetAxis("RotationX");
        float z = 90.0f * Input.GetAxis("RotationZ");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(x, 0, z), Time.time * 0.1f);
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(transform.up * 9.81f * (Input.GetAxis("Vertical") + 1.0f));
    }
}

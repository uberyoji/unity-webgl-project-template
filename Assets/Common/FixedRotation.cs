using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    public Vector3 Speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Speed);
    }
}

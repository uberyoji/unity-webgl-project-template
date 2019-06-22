using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRangeRotation : MonoBehaviour
{
    public Vector3 Speed;

    // Start is called before the first frame update
    void Start()
    {
        Speed.x = Random.Range(-Speed.x, Speed.x);
        Speed.y = Random.Range(-Speed.x, Speed.y);
        Speed.z = Random.Range(-Speed.x, Speed.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Speed);
    }
}

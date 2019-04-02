using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollision : MonoBehaviour
{
    Transform transform;
    void Start()
    {
        transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public struct Coordination
{
    float x;
    float y;
}

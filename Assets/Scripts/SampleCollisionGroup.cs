using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollisionGroup : MonoBehaviour
{
    public static List<SampleCollision> group = new List<SampleCollision>();

    void Update()
    {
        for (int i = 0; i < group.Count; i++)
        {
            for (int j = i + 1; j < group.Count; j++)
            {

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollision : MonoBehaviour
{
    Transform transform;
    CollisionStruct coor;
    public float radius;
    void Start()
    {
        transform = this.transform;
        coor = new CollisionStruct()
        {
            x = transform.position.x,
            y = transform.position.y,
            radiusSquare = radius * radius
        };
        SampleCollisionGroup.group.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(coor.x, coor.y, -0.5f);
    }

    public bool DetectCollision(SampleCollision other)
    {
        return coor.CheckCollisin(ref other.coor);
    }
}

public struct CollisionStruct
{
    public float x;
    public float y;

    public float radiusSquare;

    public float SquareDistance(ref CollisionStruct other)
    {
        return (this.x - other.x) * (this.x - other.x) + (this.y - other.y) * (this.y - other.y);
    }

    public bool CheckCollisin(ref CollisionStruct other)
    {
        return this.radiusSquare - this.SquareDistance(ref other) < 0;
    }
}

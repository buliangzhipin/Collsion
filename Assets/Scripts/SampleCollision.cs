using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollision : MonoBehaviour
{
    Transform trans;
    public CollisionStruct coor = new CollisionStruct();
    public Renderer mesh;

    public Material defaultMat;
    public Material collisionMat;

    static Color collisionColor = new Color(255, 0, 0, 1);
    public float radius;
    void Start()
    {
        SampleCollisionGroup.group.Add(this);
        mesh = this.GetComponent<Renderer>();
        trans = this.transform;
        // coor.x = trans.position.x;
        // coor.y = trans.position.y;
        // coor.radiusSquare = radius * radius;
    }

    public void SetCoor()
    {
        coor.x = trans.position.x;
        coor.y = trans.position.y;
        coor.radiusSquare = radius * radius;
    }



    public void CollisionUpdate()
    {
        trans.position = new Vector3(coor.x, coor.y, -0.5f);
    }

    public void OnCollision()
    {
        mesh.material.color = collisionColor;

    }

    public void Move(float x, float y)
    {
        coor.x += x;
        coor.y += y;
    }

    public bool DetectCollision(SampleCollision other)
    {
        return coor.CheckCollision(ref other.coor);
    }
}

public class CollisionStruct
{
    public float x;
    public float y;

    public float radiusSquare;

    public float SquareDistance(ref CollisionStruct other)
    {
        return (this.x - other.x) * (this.x - other.x) + (this.y - other.y) * (this.y - other.y);
    }

    public bool CheckCollision(ref CollisionStruct other)
    {
        return this.SquareDistance(ref other) - this.radiusSquare < 0;
    }
}

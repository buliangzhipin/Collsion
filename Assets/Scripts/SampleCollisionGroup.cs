using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollisionGroup : MonoBehaviour
{
    public SampleCollision goOrigin;
    public static List<SampleCollision> group = new List<SampleCollision>();
    public bool firstUpdate = true;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            SampleCollision go = Instantiate(goOrigin);
            go.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-5.0f, 5.0f), 1);
            go.radius = 0.5f;
        }
    }

    void Update()
    {
        if (firstUpdate)
        {
            firstUpdate = false;
            group.ForEach((i) => i.SetCoor());
        }
        for (int i = 0; i < group.Count; i++)
        {
            var collision = group[i];
            for (int j = i + 1; j < group.Count; j++)
            {
                var collision2 = group[j];
                if (collision.DetectCollision(collision2))
                {
                    collision.OnCollision();
                    collision2.OnCollision();
                }
            }
        }
    }
}

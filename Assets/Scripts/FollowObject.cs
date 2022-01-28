using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float height;

    void Update()
    {
        transform.position = target.position + new Vector3(0f, height, -distance);
    }
}

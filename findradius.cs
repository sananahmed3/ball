using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findradius : MonoBehaviour
{
    void Start()
    {
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log("Capsule Collider Radius: " + capsuleCollider.radius);
    }
}

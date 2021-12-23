using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlocker : MonoBehaviour
{
    public BoxCollider2D characterCollider;
    public BoxCollider2D blockerCollider;

    private float sizeDifference = 0.05f;

    void Start()
    {
        // Ignore collision between dynamic and kinematic RigidBody
        Physics2D.IgnoreCollision(characterCollider, blockerCollider, true);

        // Set blocker collider size slightly larger than parent collider size
        blockerCollider.offset = characterCollider.offset;
        blockerCollider.size = characterCollider.size + new Vector2(sizeDifference, sizeDifference);
    }
}

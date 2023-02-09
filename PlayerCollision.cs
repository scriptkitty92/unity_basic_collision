using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Vector2 colliderSize;
    Vector2 colliderPosition;
    Vector2 colliderDimensions;
    Vector2 point1;
    Vector2 point2;
    Vector2 point3;
    Vector2 point4;

    public Vector2 getColliderPosition() 
    {
        return colliderPosition;
    }

    public Vector2 getColliderDimensions()
    {
        return colliderDimensions;
    }

    public Vector2 getColliderSize()
    {
        return colliderSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colliderPosition.x = transform.position.x - (colliderSize.x / 2);
        colliderPosition.y = transform.position.y - (colliderSize.y / 2);
        colliderDimensions.x = colliderPosition.x + colliderSize.x;
        colliderDimensions.y = colliderPosition.y + colliderSize.y;

        point1.x = colliderPosition.x;
        point1.y = colliderPosition.y;

        point2.x = colliderPosition.x;
        point2.y = colliderDimensions.y;

        point3.x = colliderDimensions.x;
        point3.y = colliderDimensions.y;

        point4.x = colliderDimensions.x;
        point4.y = colliderPosition.y;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(colliderPosition, colliderDimensions);
        Gizmos.DrawLine(point1, point2);
        Gizmos.DrawLine(point2, point3);
        Gizmos.DrawLine(point3, point4);
        Gizmos.DrawLine(point4, point1);
    }
}

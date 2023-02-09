using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public Vector2 hitboxSize;
    Vector2 hitboxPos;
    Vector2 hitboxDim;
    Vector2 point1;
    Vector2 point2;
    Vector2 point3;
    Vector2 point4;

    public Vector2 getDimensions() 
    {
        return hitboxDim;
    }
    public Vector2 getPosition()
    {
        return hitboxPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitboxPos.x = transform.position.x - (hitboxSize.x / 2);
        hitboxPos.y = transform.position.y - (hitboxSize.y / 2);
        hitboxDim.x = hitboxPos.x + hitboxSize.x;
        hitboxDim.y = hitboxPos.y + hitboxSize.y;

        point1.x = hitboxPos.x;
        point1.y = hitboxPos.y;

        point2.x = hitboxPos.x;
        point2.y = hitboxDim.y;

        point3.x = hitboxDim.x;
        point3.y = hitboxDim.y;

        point4.x = hitboxDim.x;
        point4.y = hitboxPos.y;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(hitboxPos, hitboxDim);
        Gizmos.DrawLine(point1, point2);
        Gizmos.DrawLine(point2, point3);
        Gizmos.DrawLine(point3, point4);
        Gizmos.DrawLine(point4, point1);
    }
}

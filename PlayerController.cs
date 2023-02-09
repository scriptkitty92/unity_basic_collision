using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector2 lastPosition;
    float angle;
    public float moveAmount;

    Vector2 RaycastPosition(Vector2 position, Vector2 nextPosition, Vector2 size, float angle) 
    {
        float distance;
        Vector2 colliderCheck = position;

        

        GameObject[] colliders = GameObject.FindGameObjectsWithTag("Collider");
        for (int i = 0; i < colliders.Length; i++)
        {
            ObjectCollision collision = colliders[i].GetComponent<ObjectCollision>();
            Vector2 hitboxDim = collision.getDimensions();
            Vector2 hitboxPos = collision.getPosition();
            
            distance = Vector2.Distance(position, nextPosition);
            
            for (int j = 1; j <= 10; j++)
            {
                colliderCheck = position;
                colliderCheck.x += j * 0.1f * distance * Mathf.Cos(angle);
                colliderCheck.y += j * 0.1f * distance * Mathf.Sin(angle);

                if (((colliderCheck.x - (size.x / 2) > hitboxPos.x) && (colliderCheck.x - (size.x / 2)) < hitboxDim.x) && ((colliderCheck.y - (size.y / 2)) > hitboxPos.y) && (colliderCheck.y - (size.y / 2)) < hitboxDim.y)
                { 
                        colliderCheck = position;
                        colliderCheck.x = (j - 1) * 0.1f * distance * Mathf.Cos(angle);
                        colliderCheck.y = (j - 1) * 0.1f * distance * Mathf.Sin(angle);
                        position.x += colliderCheck.x;
                        position.y += colliderCheck.y;
                        return position;
                    
                    
                }
            }
        }
        return nextPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        PlayerCollision playerCollision = this.GetComponent<PlayerCollision>();
        Vector2 size = playerCollision.getColliderSize();
        Vector2 velocity;
        Vector2 nextPosition = position;


        if (horizontal > 0) 
        {
            nextPosition.x += moveAmount * 1f * Time.deltaTime;
        }
        if (horizontal < 0) 
        {
            nextPosition.x += moveAmount * -1f * Time.deltaTime;
        }
        if(vertical > 0) 
        {
            nextPosition.y += moveAmount * 1f * Time.deltaTime;
        }
        if (vertical < 0) 
        {
            nextPosition.y += moveAmount * -1f * Time.deltaTime;
        }
        
        angle = Mathf.Atan2 (nextPosition.y - position.y, nextPosition.x - position.x);


        //manual non-unity raycast here
        

        position = RaycastPosition(position, nextPosition, size, angle);

        transform.position = position;
    }
}

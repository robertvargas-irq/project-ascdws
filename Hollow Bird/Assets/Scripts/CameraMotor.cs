using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : Movement
{
    public Transform lookAt; // allows for dynamic focus
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    public float panicDistance = 2;
    public float panicEnd = 0;

    protected override void Start()
    {
        base.Start();

        blockingMasks = new string[]{"Border"};
        // transform.position = new Vector3(lookAt.position.x, lookAt.position.y, transform.position.z);
    }
    // Late Update is called AFTER Update and Fixed Update
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero; // difference between this frame and next frame

        // check bounds for X axis
        float deltaX = lookAt.position.x - transform.position.x; // get focus area and transform position's X
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                // move left
                delta.x = deltaX - boundX;
            }
            else
            {
                // move right
                delta.x = deltaX + boundX;
            }
        }


        // check bounds for Y axis
        float deltaY = lookAt.position.y - transform.position.y; // get focus area and transform position's Y
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                // move left
                delta.y = deltaY - boundY;
            }
            else
            {
                // move right
                delta.y = deltaY + boundY;
            }
        }

        // !PANIC: If player is too far from camera disable collision for a brief moment
        if (Mathf.Abs(deltaX) > Mathf.Abs(boundX) + panicDistance || Mathf.Abs(deltaY) > Mathf.Abs(boundY) + panicDistance)
        {
            collisions = false;
            panicEnd = 1 + Time.fixedTime;
            Debug.Log("PANIC!!!" + "deltaX:" + deltaX + "> boundX*2: " + (boundX * 2));
            Debug.Log("PANIC!!!" + "deltaY:" + deltaY + "> boundY*2: " + (boundY * 2));
        }
        else if (Time.fixedTime >= panicEnd)
            collisions = true;
        else
            Debug.Log("PANIC!!!");

        // move camera
        MoveDirection(new Vector2(delta.x, delta.y), false);
        // transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

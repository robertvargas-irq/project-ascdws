using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt; // allows for dynamic focus
    public float boundX = 0.15f;
    public float boundY = 0.05f;

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

        // move camera
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

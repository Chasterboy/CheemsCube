using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public GameObject target; // Objeto objetivo
    Vector2 firstPressPos;
    Vector2 secondPos;
    Vector2 currentSwipe;

    float rotationSpeed = 200f;

    // Update is called once per frame
    void Update()
    {
        Swipe();
        RotateTowardsTarget();
    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = Input.mousePosition;
            currentSwipe = (secondPos - firstPressPos).normalized;

            if (LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
        }
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    void RotateTowardsTarget()
    {
        if (transform.rotation == target.transform.rotation)
        {
            return;
        }

        var step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
    }
}

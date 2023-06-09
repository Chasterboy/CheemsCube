using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public GameObject target; // Objeto objetivo
    Vector2 firstPressPos;
    Vector2 secondPos;
    Vector2 currentSwipe;

    float speed = 200f;

    float rotationSpeed = 200f;
    Vector3 MousePsition;
    Vector3 mousedelta;

    // Update is called once per frame
    void Update()
    {
        Swipe();
        if (transform.rotation != target.transform.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }
    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPos.x - firstPressPos.x, secondPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            if (LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (UpRightSwipe(currentSwipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, -90, Space.World);

            }

        }
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }
    bool UpRightSwipe(Vector2 swiper)
    {

        return currentSwipe.y > 0 && currentSwipe.x > 0f;

    }
    bool DownLeftSwipe(Vector2 swiper)
    {

        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }
    bool DownRightSwipe(Vector2 swiper)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }


}

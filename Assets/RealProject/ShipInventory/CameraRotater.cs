using System.Collections;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    [SerializeField] private RectTransform touchArea;
    [SerializeField] private float rotateSpeed = 0.01f;

    private Touch prevTouch;
    private int prevTouchCount = 0;
    private bool touchSet = false;
    private bool isRotating;
    public bool IsRotating() { return isRotating; }

    void Update()
    {
        isRotating = false;
        if (Input.touchCount == 1)
        {
            Touch curTouch = Input.GetTouch(0);
            if (curTouch.phase == TouchPhase.Began || curTouch.phase == TouchPhase.Stationary || prevTouchCount != 1)
            {
                prevTouch = curTouch;
            }
            else
            {
                bool touchWithinArea;
                if (touchArea == null)
                    touchWithinArea = true;
                else
                    touchWithinArea = RectTransformUtility.RectangleContainsScreenPoint(touchArea, curTouch.position);

                if (!touchSet && touchWithinArea)
                    touchSet = true;
                else if (touchSet && !touchWithinArea)
                    touchSet = false;
                else if (touchSet && touchWithinArea)
                {
                    isRotating = true;
                    HandleRotation(curTouch);
                }
            }
        }
        else { touchSet = false; }

        prevTouchCount = Input.touchCount;
    }

    void HandleRotation(Touch curTouch)
    {
        Vector2 deltaPos = prevTouch.position - curTouch.position;
        Vector2 rotateAmount = deltaPos * rotateSpeed * Time.deltaTime;

        transform.Rotate(transform.up, rotateAmount.x);
        transform.Rotate(transform.right, rotateAmount.y);
    }
}

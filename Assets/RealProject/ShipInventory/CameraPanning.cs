using System.Collections;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    [SerializeField] private RectTransform touchArea;
    [SerializeField] private float panSpeed = 0.01f;

    private Touch prevTouch;
    private int prevTouchCount = 0;
    private bool touchSet = false;
    private bool isPanning;
    public bool IsPanning() { return isPanning; }

    void Update()
    {
        isPanning = false;
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
                    isPanning = true;
                    HandlePanning(curTouch);
                }
            }
        }
        else { touchSet = false; }

        prevTouchCount = Input.touchCount;
    }

    void HandlePanning(Touch curTouch)
    {
        Vector2 deltaPos = prevTouch.position - curTouch.position;
        transform.position += (deltaPos.x * Vector3.right + deltaPos.y * Vector3.forward) * panSpeed * Time.deltaTime;
    }
}

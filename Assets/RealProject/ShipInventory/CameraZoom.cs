using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 0.03f;

    private float previousBetweenFingerDistance;  //holds distance between two fingers used for zooming in previous frame

    private bool isZooming;
    public bool IsZooming() { return isZooming; }

    private void Update()
    {
        isZooming = false;
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                previousBetweenFingerDistance = (touch1.position - touch2.position).magnitude;
            }

            else
            {
                HandleCameraZoom(touch1, touch2);
                isZooming = true;
            }
        }
    }
    private void HandleCameraZoom(Touch touch1, Touch touch2)
    {
        float currentBetweenFingerDistance = (touch1.position - touch2.position).magnitude;
        float deltaFingerDistance = currentBetweenFingerDistance - previousBetweenFingerDistance;

        if (deltaFingerDistance == 0f)
            return;

        float zoomAmount = deltaFingerDistance * zoomSpeed * Time.deltaTime;
        transform.position += transform.forward * zoomAmount;

        previousBetweenFingerDistance = currentBetweenFingerDistance;
    }
}

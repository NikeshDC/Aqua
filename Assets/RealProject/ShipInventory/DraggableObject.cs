using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    class DragPoint { public Vector3 position; public Vector3 normal; }

    Camera eventCamera;
    public bool followPointerPosition;

    Vector2 pointerPosition;

    public LayerMask draggableSurface;
    public float objectHeight;

    private void Start()
    {
        eventCamera = Camera.main;
    }

    private void Update()
    {
        if (followPointerPosition && Input.GetMouseButton(0))
        {
            pointerPosition = Input.mousePosition;

            DragPoint dragPoint = GetDragPoint();
            if (dragPoint != null) 
            { 
                transform.position = dragPoint.position + dragPoint.normal.normalized * objectHeight; 
                transform.up = dragPoint.normal;
            }
        }
    }

    DragPoint GetDragPoint() 
    {
        DragPoint dragPoint = null;
        Ray ray = eventCamera.ScreenPointToRay(pointerPosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, eventCamera.farClipPlane,draggableSurface))
        {
            dragPoint = new DragPoint();
            dragPoint.position = hit.point;
            dragPoint.normal = hit.normal;
        }

        return dragPoint;
    }
}

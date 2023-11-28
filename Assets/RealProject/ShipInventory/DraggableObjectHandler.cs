using UnityEngine;

public class DraggableObjectHandler : DraggingTriggerer
{
    DraggableObject selectedDraggableObject;

    bool isDragging;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(IsDragableObjectUnderPointer(Input.mousePosition))
            {
                selectedDraggableObject.followPointerPosition = true;
                isDragging = true;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(selectedDraggableObject != null)
                selectedDraggableObject.followPointerPosition=false;
            selectedDraggableObject = null;
            isDragging=false;
        }
    }

    bool IsDragableObjectUnderPointer(Vector2 pointerpos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pointerpos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<DraggableObject>() != null)
            {
                selectedDraggableObject = hit.collider.GetComponent<DraggableObject>();
                return true;
            }
        }

        return false;
    }

    public override bool IsDragging()
    {
        return isDragging;
    }
}

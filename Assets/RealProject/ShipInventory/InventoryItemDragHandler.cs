using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragHandler : DraggingTriggerer, IBeginDragHandler ,IDragHandler, IEndDragHandler
{
    public GameObject dragObjectPrefab;
    public GameObject instantiateObjectPrefab;

    GameObject dragObject;

    bool isDragging = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragObject = Instantiate(dragObjectPrefab);
        dragObject.GetComponent<DraggableObject>().followPointerPosition = true;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        if (dragObject.GetComponent<SpawnObjectPlaceholder>().CanSpawn())
            Instantiate(instantiateObjectPrefab, dragObject.transform.position, dragObject.transform.rotation);

        isDragging = false;
        Destroy(dragObject);
    }

    public override bool IsDragging()
    {
        return isDragging;
    }
}

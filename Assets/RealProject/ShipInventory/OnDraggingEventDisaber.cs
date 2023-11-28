using UnityEngine;

public class OnDraggingEventDisabler : MonoBehaviour
{
    DraggingTriggerer[] draggingEventTriggerers;
    [SerializeField] MonoBehaviour[] onDragDisables;

    bool draggingEventInProgress = false;
    bool prevdraggingEvent = false;


    private void Start()
    {
        draggingEventTriggerers = FindObjectsByType<DraggingTriggerer>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        draggingEventInProgress = false;
        foreach(DraggingTriggerer trigger in draggingEventTriggerers)
        {
            if (trigger.IsDragging())
            {
                draggingEventInProgress = true;
                break;
            }
        }

        if(draggingEventInProgress != prevdraggingEvent)
        {
            if(draggingEventInProgress)
            {//on drag start
                foreach (MonoBehaviour objs in onDragDisables)
                    objs.enabled = false;
            }
            else
            {//on drag end
                foreach (MonoBehaviour objs in onDragDisables)
                    objs.enabled = true;
            }
        }

        prevdraggingEvent = draggingEventInProgress;
    }
}

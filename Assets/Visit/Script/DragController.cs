using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform currentTransform;
    private GameObject mainContent;
    private Vector3 currentPossition;

    private int totalChild;

    void Start()
    {
        if (currentTransform == null)
        {
            currentTransform = GetComponent<RectTransform>();
        }
    }

    bool isDragging = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        currentPossition = currentTransform.position;
        mainContent = currentTransform.parent.gameObject;
        totalChild = mainContent.transform.childCount;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //print("OnDrag called");
        currentTransform.position =
            new Vector3(currentTransform.position.x, eventData.position.y, currentTransform.position.z);

        for (int i = 0; i < totalChild; i++)
        {
            if (i != currentTransform.GetSiblingIndex())
            {
                Transform otherTransform = mainContent.transform.GetChild(i);

                //int distance = (int)Vector3.Distance(currentTransform.position, otherTransform.position);
                float distance = Mathf.Abs(currentTransform.position.y - otherTransform.position.y);
                if (otherTransform.name == "Info Card (1)")
                {
                    print("" + distance);
                }
                if (distance <= 10)
                {
                    Vector3 otherTransformOldPosition = otherTransform.position;
                    otherTransform.position = new Vector3(otherTransform.position.x, currentPossition.y,
                        otherTransform.position.z);
                    currentTransform.position = new Vector3(currentTransform.position.x, otherTransformOldPosition.y,
                        currentTransform.position.z);
                    currentTransform.SetSiblingIndex(otherTransform.GetSiblingIndex());
                    currentPossition = currentTransform.position;
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        currentTransform.position = currentPossition;
        LayoutRebuilder.ForceRebuildLayoutImmediate(mainContent.GetComponent<RectTransform>());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMoveObject : MonoBehaviour, IDragHandler, IEndDragHandler,IBeginDragHandler
{
    Vector3 initialPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

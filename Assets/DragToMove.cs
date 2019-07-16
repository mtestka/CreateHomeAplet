using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*public class DragToMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform transformCube;

    bool drag;
    [SerializeField]
    Vector2 startPoint;

    [SerializeField]
    Vector2 endPoint;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.pressPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        drag = true;
        endPoint = eventData.position;
        float x = Input.GetAxis("Mouse X") * 50 * Mathf.Deg2Rad;
        transformCube.Rotate(Vector3.down, x);
        float y = Input.GetAxis("Mouse Y") * 50 * Mathf.Deg2Rad;
        transformCube.Rotate(Vector3.right, y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        drag = false;
    }
}*/

public class DragToMove : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.y * dragSpeed, 0, pos.x * dragSpeed);

        transform.Translate(move, Space.World);
    }           
}
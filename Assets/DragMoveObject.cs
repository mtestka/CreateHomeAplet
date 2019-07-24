using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMoveObject : MonoBehaviour, IDragHandler, IEndDragHandler,IBeginDragHandler
{
    public GameObject model3D;
    Vector3 initialPosition;
    float objectScale = 0.0041f;
    float objectPosX = 10.56f, objectPosY = 0, objectPosZ = 4.51f;
    bool moving = false, instantiated = false;
    GameObject instantiatedObject = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
        moving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (moving)
        {
            transform.position = Input.mousePosition;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, 1000))
        {
            switch (hit.collider.gameObject.name)
            {
                case "LeftWall":
                    if (moving)
                    {
                        moving = false;
                        instantiated = true;
                        transform.position = initialPosition;
                        instantiatedObject = Instantiate(model3D, new Vector3(10.56f, 0, 4.51f), Quaternion.identity);
                        instantiatedObject.transform.localScale = new Vector3(objectScale, objectScale, objectScale);
                        instantiatedObject.transform.localRotation = Quaternion.Euler(90, 0, 90);
                    }
                    else if(instantiatedObject != null)
                    {
                        instantiatedObject.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    }
                    break;
                case "RightWall":
                    break;
                case "BackWall":
                    break;
                case "FrontWall":
                    break;
                default:
                    break;
            }
            Debug.Log("You hit: " + hit.point);
        }
        else
        {
            moving = true;
            if (instantiated)
            {
                Destroy(instantiatedObject);
            }
            Debug.Log("Is default state");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
        moving = false;
        instantiated = false;
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

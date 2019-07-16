using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyCube : MonoBehaviour
{
    public Slider slider;
    private Vector3 position,scale;
    public int type = 1;

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>().position;
        scale = GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1)
        {
            GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, GetComponent<Transform>().localScale.y, scale.z + (slider.value - 1));
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, position.z + 0.5f* (slider.value - 1));
        }else if(type == 2)
        {
            GetComponent<Transform>().localScale = new Vector3(scale.x+(slider.value-1), GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, position.z + 0.5f* (slider.value - 1));
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject roof, window, sideWindow, cubeMain;
    public Toggle toggleRoof, toggleFrontWindow, toggleWindowSide;
    public Material wood, bricks;
    public Slider lengthOfHouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lengthOfHouse.value < 3)
        {
            toggleWindowSide.enabled = false;
        }
        else
        {
            toggleWindowSide.enabled = true;
        }
    }

    public void SetMaterialOnCube(Material material)
    {
        cubeMain.GetComponent<Renderer>().material = material;
    }

    public void SetRoofActive()
    {
        if (toggleRoof.isOn)
        {
            roof.SetActive(true);
        }
        else
        {
            roof.SetActive(false);
        }
    }

    public void SetFrontWindowActive()
    {
        if (toggleFrontWindow.isOn)
        {
            window.SetActive(true);
        }
        else
        {
            window.SetActive(false);
        }
    }

    public void SetSideWindowActive()
    {
        if (toggleWindowSide.isOn)
        {
            sideWindow.SetActive(true);
        }
        else
        {
            sideWindow.SetActive(false);
        }
    }

    public void SetGameObjectActive(GameObject gb)
    {
        gb.SetActive(true);
    }

    public void SetGameObjectDeActive(GameObject gb)
    {
        gb.SetActive(false);
    }
}

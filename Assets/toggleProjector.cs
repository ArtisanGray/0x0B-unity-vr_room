using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleProjector : MonoBehaviour
{
    private bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggleLights()
    {
        if (toggle)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            toggle = false;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            toggle = true;
        }
    }
}

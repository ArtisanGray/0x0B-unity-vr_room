using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHit : MonoBehaviour
{
    public GameObject lefty;
    //private TeleportationHandle controllerInteractor;
    public bool safeTeleport;
    private GameObject reticle;
    private Vector3 startingPosition = new Vector3(0.0f, 6.0f, 0.0f);
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        safeTeleport = true;
    }
    private void Update()
    {
        if (lefty.GetComponent<TeleportationHandle>()._thumbstick.triggered == true)
        {
            reticle = GameObject.Find("TeleportReticle(Clone)");
            if (reticle)
                transform.position = reticle.transform.position;
        }
        else
        {
            transform.position = startingPosition;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit something!");
        safeTeleport = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("safe!");
        safeTeleport = true;
    }
}

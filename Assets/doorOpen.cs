using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    private bool isNearby;
    private Animator animator;
    public GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isNearby = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearby)
        {
            animator.SetBool("character_nearby", true);
        }
        else
            animator.SetBool("character_nearby", false);
    }
    public void setNearby()
    {
        if (isNearby)
        {
            isNearby = false;
            foreach (Transform floorchild in room.transform)
            {
                floorchild.gameObject.layer = 0;
            }
        }
        else
        {
            foreach (Transform floorchild in room.transform)
            {
                floorchild.gameObject.layer = 6;
            }
            isNearby = true;
        }
    }
}

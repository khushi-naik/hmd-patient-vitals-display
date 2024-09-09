using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr2Behavior : MonoBehaviour
{
    public Camera mainCamera;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 0.5f, 1.0f));
        transform.position = edgePosition;
        Debug.Log("Position of bp2 sphere: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o2Behavior : MonoBehaviour
{
    public Camera mainCamera;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 0.1f, 1.0f));
        transform.position = edgePosition;
        Debug.Log("Position of o22 sphere: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
    }
}

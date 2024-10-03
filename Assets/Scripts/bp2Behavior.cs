using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bp2Behavior : MonoBehaviour
{
    public Camera mainCamera;
    private Animator anim;
    private float speed = 1f;
    private float animationTimer = 0f;
    Vector3 edgePosition;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.95f, 0.3f, 1.5f));
        transform.position = edgePosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.95f, 0.3f, 1.5f));
        //transform.position = edgePosition;
        animationTimer += Time.deltaTime;
        if (animationTimer >= 1f)
        {
            animationTimer = 0f;
            transform.position = edgePosition;
        }
        else
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            
        }
        Debug.Log("Position of bp2 sphere: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
    }
}

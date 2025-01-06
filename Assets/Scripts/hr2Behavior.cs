using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr2Behavior : MonoBehaviour
{
    public Camera mainCamera;
    private Animator anim;
    private float speed = 0.5f;
    private float animationTimer = 0f;
    Vector3 edgePosition;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.92f, 0.6f, 1.2f));
        transform.position = edgePosition;
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = 0;
        if (CommonPrototypeVariables.isExperimentStarted)
        {
            animationTimer += Time.deltaTime;
            if (animationTimer >= 1f)
            {
                animationTimer = 0f;
                transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.92f, 0.6f, 1.2f));

            }
            else
            {
                //Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
                //transform.Translate(directionToCamera * speed * Time.deltaTime, Space.World);

                //transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
                //transform.Translate(-Vector3.forward * speed *Time.deltaTime, Space.World);
            }

            //Debug.Log("Position of hr2 sphere: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
        }
    }
}

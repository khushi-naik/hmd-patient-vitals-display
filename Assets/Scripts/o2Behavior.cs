using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class o2Behavior : MonoBehaviour
{
    public Camera mainCamera;
    private Animator anim;
    private float speed = 0.3f;
    private float animationTimer = 0f;
    Vector3 edgePosition;
    private float elapsedTime = 0f;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    private string animType = "";
    private int currentBlockIndex = 0;
    private int currentValueIndex = 0;
    private O2Block2[] expArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;

    //private startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        anim = GetComponent<Animator>();
        expArray = O22ExperimentSequence.O2ExperimentBlock2;
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.9f, 0.4f, 1f));
        transform.position = edgePosition;
        //startPosition = 

        alarmLog = new bool[expArray.Length];
        GameObject obj = GameObject.Find("testTCP");
        if (obj != null)
        {
            tcpObj = obj.GetComponent<TcpConnectionScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CommonPrototypeVariables.isExperimentStarted)
        {
            O2Block2 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    anim.speed = 0;
                    animType = "";
                    transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.9f, 0.4f, 1f));
                    int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    int currentVital = currentBlock.vitalValue[currentValueIndex];
                    if (currentVital > previousVital)
                    {
                        //animType = "highAnim";
                    }
                    else if (currentVital < previousVital)
                    {
                        if (currentVital >= 90 && currentVital <= 95)
                        {

                            //anim.Play("o2NormalToLow");//change
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O22, normal to low_blockno" + currentBlockIndex + "_curval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;

                            }
                            animType = "lowAnim";

                        }
                    }
                    else if (currentVital == previousVital)
                    {
                        if (currentVital >= 96)
                        {
                            //Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
                            //edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.92f, 0.4f, 1.2f));
                            //transform.position = edgePosition;
                        }
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }

                    elapsedTimeNumber = 0f;
                }
                else
                {
                    Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
                    //Vector3 currentPosition = transform.position;
                    //float newZ = Mathf.Lerp(startPosition.z, targetPosition.z, moveProgress);
                    //transform.position = new Vector3(currentPosition.x, currentPosition.y, newZ);

                    if (animType.Equals("lowAnim"))
                    {
                        anim.speed = 0.5f;
                        anim.Play("o2NormalToLow");
                        transform.Translate(-directionToCamera * speed * Time.deltaTime, Space.World);
                    }
                    else if (animType.Equals("highAnim"))
                    {
                        anim.speed = 0.5f;
                        transform.Translate(directionToCamera * speed * Time.deltaTime, Space.World);
                    }
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
        /*if (CommonPrototypeVariables.isExperimentStarted)
        {
            //Vector3 edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.95f, 0.1f, 1.5f));
            //transform.position = edgePosition;
            animationTimer += Time.deltaTime;
            if (animationTimer >= 1f)
            {
                animationTimer = 0f;
                transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.92f, 0.4f, 1.2f));

            }
            else
            {
                Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
                transform.Translate(directionToCamera * speed * Time.deltaTime, Space.World);

                //transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
                //transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            //Debug.Log("Position of o22 sphere: " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
        }*/
    }
}
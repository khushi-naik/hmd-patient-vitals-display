using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class o2Behavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    //public TextMeshProUGUI textO2;
    //public TextMeshProUGUI textHr;
    //public TextMeshProUGUI textBp;
    //public TextMeshProUGUI probeAlertText;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //O21Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";
    private O2Block2[] expArray;
    bool[] alarmLog;
    private TcpConnectionScript tcpObj;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0.5f;
        anim.Play("justMove");
        expArray = O22ExperimentSequence.O2ExperimentBlock2;
        //textO2.enabled = false;
        alarmLog = new bool[expArray.Length];

        GameObject obj = GameObject.Find("testTCP");
        if (obj != null)
        {
            tcpObj = obj.GetComponent<TcpConnectionScript>();
        }

    }

    private void Update()
    {
        if (CommonPrototypeVariables.isExperimentStarted)
        {

            if (currentBlockIndex < expArray.Length)
            {
                O2Block2 currentBlock = expArray[currentBlockIndex];
                
                if (elapsedTimeNumber >= updateTime)
                {

                    float previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    float currentVital = currentBlock.vitalValue[currentValueIndex];
                    if (currentVital > previousVital)
                    {
                        if (currentVital >= 90 && currentVital <= 95)
                        {
                            anim.speed = 0.5f;
                            //anim.Play("o2ReturnLowToNormal");
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                       
                        else if (currentVital >= 96)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        previousTrend = "increase";
                    }
                    else if (currentVital < previousVital)
                    {
                        if (currentVital >= 90 && currentVital <= 95)
                        {
                            anim.speed = 1.25f;
                            anim.Play("o2NormalToLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O22, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        
                        else if (currentVital >= 96)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        previousTrend = "decrease";
                    }
                    else if (currentVital == previousVital)
                    {
                        if (currentVital >= 96)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                        }
                        else if (currentVital >= 90 && currentVital <= 95)
                        {
                            anim.speed = 0.5f;
                            if (previousTrend.Contains("increase"))
                            {
                                //anim.Play("o2StaticVeryLowToLow");
                                anim.Play("justMove");
                            }
                            else
                            {
                                //anim.Play("o2StaticNormalToLow");
                                anim.Play("justMove");
                            }

                        }
                        
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                    //textO2.text = "O2: " + O21ExperimentSequence.o21Block1Start.ToString();
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }
    /*public Camera mainCamera;
    private float speed = 1f;
    //private float animationTimer = 0f;
    Vector3 edgePosition;
    //private float elapsedTime = 0f;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    private string animType = "";
    private int currentBlockIndex = 0;
    private int currentValueIndex = 0;
    private O2Block2[] expArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;

    private Vector3 startPosition;
    private float moveProgress = 0f;

    void Start()
    {
        expArray = O22ExperimentSequence.O2ExperimentBlock2;
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.4f, 0.9f));
        transform.position = edgePosition;

        alarmLog = new bool[expArray.Length];
        GameObject obj = GameObject.Find("testTCP");
        if (obj != null)
        {
            tcpObj = obj.GetComponent<TcpConnectionScript>();
        }
    }


    void Update()
    {
        if (CommonPrototypeVariables.isExperimentStarted)
        {
            O2Block2 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    //reset animation variables
                    moveProgress = 0f;
                    animType = "";
                    transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.4f, 0.9f));
                    startPosition = transform.position;
                    transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);

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
                    //color animation
                    Renderer objRenderer = GetComponent<Renderer>();
                    Color startColor = new Color(0.6f, 0.6f, 1.0f, 1.0f);
                    Color targetColor = new Color(0.4f, 0.4f, 1.0f, 1.0f);
                    objRenderer.material.color = Color.Lerp(startColor, targetColor, moveProgress);

                    Vector3 startScale = new Vector3(0.025f, 0.025f, 0.025f);

                    if (animType.Equals("lowAnim"))
                    {
                        moveProgress += Time.deltaTime * speed;
                        //move animation-backward
                        Vector3 currentPosition = transform.position;
                        Vector3 targetPosition = startPosition + (directionToCamera * -0.02f);
                        transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
                        //scale animation
                        Vector3 targetScale = new Vector3(0.02f, 0.02f, 0.02f); // Larger scale (1.5x)
                        transform.localScale = Vector3.Lerp(startScale, targetScale, moveProgress);
                    }
                    else if (animType.Equals("highAnim"))
                    {
                        moveProgress += Time.deltaTime * speed;
                        //move animation-forward
                        Vector3 currentPosition = transform.position;
                        Vector3 targetPosition = startPosition + (directionToCamera * 0.02f);
                        transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
                        //scale animation
                        Vector3 targetScale = new Vector3(0.05f, 0.05f, 0.05f); // Larger scale (1.5x)
                        transform.localScale = Vector3.Lerp(startScale, targetScale, moveProgress);
                    }
                    else
                    {
                        transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.4f, 0.9f));
                    }
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }      
    }*/
}
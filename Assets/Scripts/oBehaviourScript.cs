using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class oBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textO2;
    public TextMeshProUGUI textHr;
    public TextMeshProUGUI textBp;
    public TextMeshProUGUI probeAlertText;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //O21Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";
    private O2Block1[] expArray;
    bool[] alarmLog;
    private TcpConnectionScript tcpObj;
    private bool probeMsgSent =false;
    private float previousVital;

    void Start()
    {
        anim = GetComponent<Animator>();
        expArray = O21ExperimentSequence.o2ExperimentBlock1;
        textO2.enabled = false;
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
                O2Block1 currentBlock = expArray[currentBlockIndex];
                if (currentBlock.isProbe)
                {
                    probeAlertText.enabled = true;
                    GameObject[] objectsToHide = GameObject.FindGameObjectsWithTag("hideDuringProbe");

                    // Loop through each GameObject and disable its renderer
                    foreach (GameObject obj in objectsToHide)
                    {
                        Renderer renderer = obj.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.enabled = false;
                        }
                    }
                    textO2.enabled = false;
                    textBp.enabled = false;
                    textHr.enabled = false;
                    textHr.GetComponent<BoxCollider>().enabled = false;
                    if (!probeMsgSent)
                    {
                        tcpObj.sendMessage("probeitis," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        probeMsgSent = true;
                    }
                    
                }
                else
                {
                    probeAlertText.enabled = false;
                    GameObject[] objectsToHide = GameObject.FindGameObjectsWithTag("hideDuringProbe");

                    // Loop through each GameObject and disable its renderer
                    foreach (GameObject obj in objectsToHide)
                    {
                        Renderer renderer = obj.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.enabled = true;
                        }
                    }
                    probeMsgSent = false;
                    //textO2.enabled = true;
                    //textBp.enabled = true;
                    //textHr.enabled = true;
                    //textHr.GetComponent<BoxCollider>().enabled = true;
                }
                if (elapsedTimeNumber >= updateTime)
                {
                    int countDownValue = currentBlock.vitalValue.Length - currentValueIndex - 1;
                    if(countDownValue > 0)
                    {
                        probeAlertText.text = "Please answer to the probe in " + countDownValue.ToString();
                    }
                    else
                    {
                        probeAlertText.text = "Please answer to the probe in 20";
                    }
                    if (currentValueIndex == 0)
                    {
                        previousVital = O21ExperimentSequence.o21Block1Start;
                    }
                    else
                    {
                        previousVital = currentBlock.vitalValue[currentValueIndex - 1];
                    }
                    //float previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    O21ExperimentSequence.o21Block1Start = currentBlock.vitalValue[currentValueIndex];
                    if (O21ExperimentSequence.o21Block1Start > previousVital)
                    {
                        /*if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.speed = 0.5f;
                            anim.Play("o2ReturnLowToNormal");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (O21ExperimentSequence.o21Block1Start <= 89)
                        {
                            anim.speed = 0.5f;
                            anim.Play("o2ReturnVeryLowToLow");
                            alarmLog[currentBlockIndex] = false;
                        }*/
                        if (O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.speed = 0.5f;
                            anim.Play("o2ReturnLowToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (O21ExperimentSequence.o21Block1Start >= 96)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveO");
                            alarmLog[currentBlockIndex] = false;
                        }
                        previousTrend = "increase";
                    }
                    else if (O21ExperimentSequence.o21Block1Start < previousVital)
                    {
                        /*if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.speed = 1.25f;
                            anim.Play("o2NormalToLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O21, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (O21ExperimentSequence.o21Block1Start <= 89)
                        {
                            anim.speed = 1.50f;
                            anim.Play("o2LowToVeryLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O21, low to very low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }*/
                        if (O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.speed = 1.75f;
                            anim.Play("o2NormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                //tcpObj.sendMessage("hello from script");
                                Debug.Log("O21,expA1 normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("O21,expA1 normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;

                            }
                        }
                        else if (O21ExperimentSequence.o21Block1Start >= 96)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveO");
                            alarmLog[currentBlockIndex] = false;
                        }
                        previousTrend = "decrease";
                    }
                    else if (O21ExperimentSequence.o21Block1Start == previousVital)
                    {
                        if (O21ExperimentSequence.o21Block1Start >= 96)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveO");
                        }
                        else if (O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.speed = 0.5f;
                            anim.Play("o2StaticNormalToLow2");
                        }
                        /*else if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.speed = 0.5f;
                            if (previousTrend.Contains("increase"))
                            {
                                anim.Play("o2StaticVeryLowToLow");
                            }
                            else
                            {
                                anim.Play("o2StaticNormalToLow");
                            }

                        }
                        else if (O21ExperimentSequence.o21Block1Start <= 89)
                        {
                            anim.speed = 0.5f;
                            anim.Play("o2StaticLowToVeryLow");
                        }*/
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                    textO2.text = "O2: " + O21ExperimentSequence.o21Block1Start.ToString();
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }

}

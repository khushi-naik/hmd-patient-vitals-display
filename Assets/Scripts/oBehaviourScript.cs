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
                }
                else
                {
                    probeAlertText.enabled = false;
                }
                if (elapsedTimeNumber >= updateTime)
                {
                    int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    O21ExperimentSequence.o21Block1Start = currentBlock.vitalValue[currentValueIndex];
                    if (O21ExperimentSequence.o21Block1Start > previousVital)
                    {
                        if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.Play("o2ReturnLowToNormal");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (O21ExperimentSequence.o21Block1Start <= 89)
                        {
                            anim.Play("o2ReturnVeryLowToLow");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (O21ExperimentSequence.o21Block1Start >= 96)
                        {
                            anim.Play("justMoveO");
                            alarmLog[currentBlockIndex] = false;
                        }
                        previousTrend = "increase";
                    }
                    else if (O21ExperimentSequence.o21Block1Start < previousVital)
                    {
                        if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                        {
                            anim.Play("o2NormalToLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O21, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (O21ExperimentSequence.o21Block1Start <= 89)
                        {
                            anim.Play("o2LowToVeryLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O21, low to very low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (O21ExperimentSequence.o21Block1Start >= 96)
                        {
                            anim.Play("justMoveO");
                            alarmLog[currentBlockIndex] = false;
                        }
                        previousTrend = "decrease";
                    }
                    else if (O21ExperimentSequence.o21Block1Start == previousVital)
                    {
                        if (O21ExperimentSequence.o21Block1Start >= 96)
                        {
                            anim.Play("justMoveO");
                        }
                        else if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                        {
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
                            anim.Play("o2StaticLowToVeryLow");
                        }
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

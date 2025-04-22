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
                        if (currentVital <= 95)
                        {
                            anim.speed = 0.5f;
                            //anim.Play("o2ReturnLowToNormal");
                            anim.Play("os2ReturnLowToNormal2");
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
                        if (currentVital <= 95)
                        {
                            anim.speed = 1.75f;
                            anim.Play("os2NormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("O22, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + O21ExperimentSequence.o21Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                        else if (currentVital <= 95)
                        {
                            anim.speed = 0.5f;
                            anim.Play("os2StaticNormalToLow2");

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
    
}
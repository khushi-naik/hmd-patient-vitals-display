using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hr2Behavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    //public TextMeshProUGUI textHr;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";

    private bool alarmLogged = false;
    private string filePath;
    HrBlock2[] expArray;
    int prevValue = 0;
    bool[] alarmLog;
    private TcpConnectionScript tcpObj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0.5f;
        anim.Play("justMove");
        //testArray = HR1ExperimentSequence.expSeq;
        expArray = HR2ExperimentSequence.hrExperimentBlock2;

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
            HrBlock2 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {

                if (elapsedTimeNumber >= updateTime)
                {
                    int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    int currentVital = currentBlock.vitalValue[currentValueIndex];
                    
                    // Play different animations based on conditions
                    if (currentVital > previousVital)
                    {
                        if (currentVital >= 100)
                        {
                            anim.speed = 1.75f;
                            anim.Play("hr2NormalToHigh2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("HR2, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("HR2, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }

                        }
                       
                        else if (currentVital > 59 && currentVital < 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (currentVital <= 59)
                        {
                            anim.speed = 0.5f;
                            //anim.Play("hrReturnLowToNormal");
                            anim.Play("hr2ReturnLowToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        
                        previousTrend = "increase";

                    }
                    else if (currentVital < previousVital)
                    {
                        if (currentVital <= 59)
                        {
                            anim.speed = 1.75f;
                            anim.Play("hr2NormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("HR2, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("HR2, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }

                        }
                
                        else if (currentVital > 59 && currentVital < 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (currentVital >= 100)
                        {
                            anim.speed = 0.5f;
                            //anim.Play("hrReturnHighToNormal");
                            anim.Play("hr2ReturnHighToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                      
                        previousTrend = "decrease";

                    }
                    else if (currentVital == previousVital)
                    {
                        if (currentVital > 59 && currentVital < 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                        }
                       
                        else if (currentVital <= 59)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hr2StaticNormalToLow2");
                            
                        }
                        else if (currentVital >= 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hr2StaticNormalToHigh2");
                            
                        }
                        alarmLog[currentBlockIndex] = false;

                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                    //textHr.text = "HR: " + HR1ExperimentSequence.hr1Block1Start;
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }
    
}
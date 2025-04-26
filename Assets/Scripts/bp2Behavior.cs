using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bp2Behavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    //public TextMeshProUGUI textBp;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //Bp1Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";
    private BpBlock2[] expArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;
    private int previousVital;
    private int currentVital=125;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0.5f;
        anim.Play("justMove");
        expArray = BP2ExperimentSequence.BpExperimentBlock2;
        //textBp.enabled = false;
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
            BpBlock2 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    if (currentValueIndex == 0)
                    {
                        previousVital = currentVital;
                    }
                    else
                    {
                        previousVital = currentBlock.vitalValue[currentValueIndex - 1];
                    }
                    //int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    currentVital = currentBlock.vitalValue[currentValueIndex];
                    if (currentVital > previousVital)
                    {
                        if (currentVital >= 138)
                        {
                            anim.speed = 1.75f;
                            anim.Play("bp2NormalToHigh2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("BP2, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("BP2, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bp2ReturnLowToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                       
                        previousTrend = "increase";
                    }
                    else if (currentVital < previousVital)
                    {
                        if (currentVital <= 102)
                        {
                            anim.speed = 1.75f;
                            anim.Play("bp2NormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("BP2, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("BP2, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        
                        else if (currentVital > 102 && currentVital < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bp2ReturnHighToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        
                        previousTrend = "decrease";
                    }
                    else if (currentVital == previousVital)
                    {
                        if (currentVital > 102 && currentVital < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                        }
                       
                      
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bp2StaticNormalToLow2");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bp2StaticNormalToHigh2");
                        }
                        alarmLog[currentBlockIndex] = false;
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                    System.Random random = new System.Random();
                    int diastolicBpValue = random.Next(30, 51);
                    diastolicBpValue = currentVital - diastolicBpValue;
                    //textBp.text = "BP: " + Bp1ExperimentSequence.bp1Block1Start.ToString() + "/" + diastolicBpValue.ToString();
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class bpBehavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textBp;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //Bp1Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";
    int prevValue = 0;
    private BpBlock1[] expArray;
    private BpBlock1[] expDiastolicArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;
    int previousVital;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        expArray = Bp1ExperimentSequence.BpExperimentBlock1;
        expDiastolicArray = Bp1ExperimentSequence.BpDiastolicExperimentBlock1;
        textBp.enabled = false;
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
            BpBlock1 currentBlock = expArray[currentBlockIndex];
            BpBlock1 currentDiastolicBlock = expDiastolicArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    if (currentValueIndex == 0)
                    {
                        previousVital = Bp1ExperimentSequence.bp1Block1Start;
                    }
                    else
                    {
                        previousVital = currentBlock.vitalValue[currentValueIndex - 1];
                    }
                    //int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    int previousDiastolicVital = currentDiastolicBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    Bp1ExperimentSequence.bp1Block1Start = currentBlock.vitalValue[currentValueIndex];
                    int currentDiastolicVital = currentDiastolicBlock.vitalValue[currentValueIndex];

                    if (Bp1ExperimentSequence.bp1Block1Start > previousVital)
                    {
                        /*if (Bp1ExperimentSequence.bp1Block1Start >= 138 && Bp1ExperimentSequence.bp1Block1Start < 156)
                        {
                            anim.speed = 1.0f;
                            anim.Play("highAnim");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 156)
                        {
                            anim.speed = 1.50f;
                            anim.Play("veryHighAnim");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, high to very high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }*/
                        if (Bp1ExperimentSequence.bp1Block1Start >= 138 || currentDiastolicVital >=90)
                        {
                            anim.speed = 1.75f;
                            anim.Play("bpNormalToHigh2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("BP1,expA1 normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("BP1,expA1 normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveBp");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpReturnLowToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        /*else if (Bp1ExperimentSequence.bp1Block1Start > 84 && Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            anim.Play("lowToNormal");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 84)
                        {
                            anim.speed = 0.5f;
                            anim.Play("veryLowToLow");
                            alarmLog[currentBlockIndex] = false;
                        }*/
                        previousTrend = "increase";
                    }
                    else if (Bp1ExperimentSequence.bp1Block1Start < previousVital)
                    {
                        /*if (Bp1ExperimentSequence.bp1Block1Start <= 102 && Bp1ExperimentSequence.bp1Block1Start > 84)
                        {
                            anim.speed = 1.0f;
                            anim.Play("lowAnim");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 84)
                        {
                            anim.speed = 1.50f;
                            anim.Play("veryLowAnim");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, low to very low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }*/
                        if (Bp1ExperimentSequence.bp1Block1Start <= 102 || currentDiastolicVital<70)
                        {
                            anim.speed = 1.75f;
                            anim.Play("bpNormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("BP1,expA1 normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("BP1,expA1 normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveBp");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpReturnHighToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        /*else if (Bp1ExperimentSequence.bp1Block1Start >= 138 && Bp1ExperimentSequence.bp1Block1Start < 156)
                        {
                            anim.speed = 0.5f;
                            anim.Play("highToNormal");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 156)
                        {
                            anim.speed = 0.5f;
                            anim.Play("veryHighToHigh");
                            alarmLog[currentBlockIndex] = false;
                        }*/
                        previousTrend = "decrease";
                    }
                    else if (Bp1ExperimentSequence.bp1Block1Start == previousVital)
                    {
                        if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveBp");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102 || currentDiastolicVital < 70)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpStaticNormalToLow2");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138 || currentDiastolicVital >= 90)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpStaticNormalToHigh2");
                        }
                        /*else if (Bp1ExperimentSequence.bp1Block1Start >= 156)
                        {
                            anim.speed = 0.5f;
                            anim.Play("staticHighToVeryHighAnim");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 84)
                        {
                            anim.speed = 0.5f;
                            anim.Play("staticLowToVeryLowAnim");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102 && Bp1ExperimentSequence.bp1Block1Start > 84)
                        {
                            anim.speed = 0.5f;
                            if (previousTrend.Contains("increase"))
                            {
                                anim.Play("staticVeryLowToLowAnim");
                            }
                            else
                            {
                                anim.Play("staticNormalToLowAnim");
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138 && Bp1ExperimentSequence.bp1Block1Start < 156)
                        {
                            anim.speed = 0.5f;
                            if (previousTrend.Contains("decrease"))
                            {
                                anim.Play("staticVeryHighToHighAnim");
                            }
                            else
                            {
                                anim.Play("staticNormalToHighAnim");
                            }
                        }*/
                        alarmLog[currentBlockIndex] = false;
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                    //System.Random random = new System.Random();
                    //int diastolicBpValue = random.Next(30, 51);
                    //diastolicBpValue = Bp1ExperimentSequence.bp1Block1Start - diastolicBpValue;
                    textBp.text = "BP: " + Bp1ExperimentSequence.bp1Block1Start.ToString() + "/" + currentDiastolicVital.ToString();
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }

}

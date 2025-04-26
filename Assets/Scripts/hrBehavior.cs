using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using System;
#if WINDOWS_UWP
using Windows.Storage;
#endif


public class hrBehavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textHr;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";

    private bool alarmLogged = false;
    private string filePath;
    Block1[] expArray;
    int prevValue = 0;
    bool[] alarmLog;
    private TcpConnectionScript tcpObj;
    private int previousVital;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //testArray = HR1ExperimentSequence.expSeq;
        expArray = HR1ExperimentSequence.hrExperimentBlock1;
        textHr.enabled = false;

        filePath = Application.persistentDataPath + "/alarm_timestamps.csv";
        Debug.Log("the persistent filepath is " + filePath);
        // Check if the alarm timestamp file exists
        using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            using (var writer = new StreamWriter(file, Encoding.UTF8))
            {
                writer.Write("this is the content" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
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
            Block1 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {

                if (elapsedTimeNumber >= updateTime)
                {
                    if (currentValueIndex == 0)
                    {
                        previousVital = HR1ExperimentSequence.hr1Block1Start;
                    }
                    else
                    {
                        previousVital = currentBlock.vitalValue[currentValueIndex - 1];
                    }
                    //int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    HR1ExperimentSequence.hr1Block1Start = currentBlock.vitalValue[currentValueIndex];
                    /*elapsedTimeNumber = 0f;
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                }
                if (currentValueIndex > 0)
                {
                    prevValue = currentValueIndex - 1;
                }
                else
                {
                    prevValue = 0;
                }*/
                    // Play different animations based on conditions
                    if (HR1ExperimentSequence.hr1Block1Start > previousVital)
                    {
                        /*if (HR1ExperimentSequence.hr1Block1Start >= 100 && HR1ExperimentSequence.hr1Block1Start < 121)
                        {
                            anim.speed = 1.0f;
                            anim.Play("hrNormalToHigh");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("HR1, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }

                        }
                        else if (HR1ExperimentSequence.hr1Block1Start >= 121)
                        {
                            anim.speed = 1.50f;
                            anim.Play("hrHighToVeryHigh");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("HR1, high to very high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }

                        }*/
                        if (HR1ExperimentSequence.hr1Block1Start >= 100)
                        {
                            anim.speed = 1.75f;
                            anim.Play("hrNormalToHigh2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("HR1,expA1 normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("HR1,expA1 normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start > 59 && HR1ExperimentSequence.hr1Block1Start < 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start <= 59)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrReturnLowToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        /*else if (HR1ExperimentSequence.hr1Block1Start > 44 && HR1ExperimentSequence.hr1Block1Start <= 59)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrReturnLowToNormal");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start <= 44)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrReturnVeryLowToLow");
                            alarmLog[currentBlockIndex] = false;
                        }*/
                        previousTrend = "increase";

                    }
                    else if (HR1ExperimentSequence.hr1Block1Start < previousVital)
                    {
                        /*if (HR1ExperimentSequence.hr1Block1Start <= 59 && HR1ExperimentSequence.hr1Block1Start > 44)
                        {
                            anim.speed = 1.0f;
                            anim.Play("hrNormalToLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("HR1, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }

                        }
                        else if (HR1ExperimentSequence.hr1Block1Start <= 44)
                        {
                            anim.speed = 1.50f;
                            anim.Play("hrLowToVeryLow");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("HR1, low to very low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }

                        }*/
                        if (HR1ExperimentSequence.hr1Block1Start <= 59)
                        {
                            anim.speed = 1.75f;
                            anim.Play("hrNormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                Debug.Log("HR1,expA1 normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                tcpObj.sendMessage("HR1,expA1 normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start > 59 && HR1ExperimentSequence.hr1Block1Start < 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start >= 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrReturnHighToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        /*else if (HR1ExperimentSequence.hr1Block1Start >= 100 && HR1ExperimentSequence.hr1Block1Start < 121)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrReturnHighToNormal");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start >= 121)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrReturnVeryHighToHigh");
                            alarmLog[currentBlockIndex] = false;
                        }*/
                        previousTrend = "decrease";
                   
                    }
                    else if (HR1ExperimentSequence.hr1Block1Start == previousVital)
                    {
                        if (HR1ExperimentSequence.hr1Block1Start > 59 && HR1ExperimentSequence.hr1Block1Start < 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start <= 59)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrStaticNormalToLow2");
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start >= 100)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrStaticNormalToHigh2");
                        }
                        /*else if (HR1ExperimentSequence.hr1Block1Start >= 121)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrStaticHighToVeryHigh");
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start <= 44)
                        {
                            anim.speed = 0.5f;
                            anim.Play("hrStaticLowToVeryLow");
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start <= 59 && HR1ExperimentSequence.hr1Block1Start > 44)
                        {
                            anim.speed = 0.5f;
                            if (previousTrend.Contains("increase"))
                            {
                                anim.Play("hrStaticVeryLowToLow");
                            }
                            else
                            {
                                anim.Play("hrStaticNormalToLow");
                            }
                        }
                        else if (HR1ExperimentSequence.hr1Block1Start >= 100 && HR1ExperimentSequence.hr1Block1Start < 121)
                        {
                            anim.speed = 0.5f;
                            if (previousTrend.Contains("decrease"))
                            {
                                anim.Play("hrStaticVeryHighToHigh");
                            }
                            else
                            {
                                anim.Play("hrStaticNormalToHigh");
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
                    textHr.text = "HR: " + HR1ExperimentSequence.hr1Block1Start;
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }


    /*void LogTimestampOfAlarm()
    {
        if (!alarmLogged)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //Block item = testArray[currentBlockIndex];
            Debug.Log("Alarm triggered at: " + timestamp);
            alarmLogged = true;

            // Append the timestamp to the CSV file
            using (var file = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (var writer = new StreamWriter(file, Encoding.UTF8))
                {
                    writer.WriteLine("hr1 alarm " + timestamp);
                    Debug.Log("hr1 alarm " + timestamp);
                }
            }

        }
    }*/

}

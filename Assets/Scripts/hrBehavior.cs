using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using System;

public class hrBehavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textHr;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";

    private bool alarmLogged = false;
    private string filePath;
    Block1[] expArray;
    int prevValue=0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        testArray = ExperimentSequenceSingleton.expSeq;
        expArray = ExperimentSequenceSingleton.hrExperimentBlock1;
        textHr.enabled = false;

        filePath = Application.dataPath + "/alarm_timestamps.csv";

        // Check if the alarm timestamp file exists
        if (!File.Exists(filePath))
        {
            // Create the file and write the header
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Alarm Timestamp");
            }
        }
        //StartCoroutine(PlayAnimations());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBlockIndex < expArray.Length)
        {
            Block1 currentBlock = expArray[currentBlockIndex];
            if(elapsedTimeNumber >= updateTime)
            {
                ExperimentSequenceSingleton.hr1Block1Start = currentBlock.vitalValue[currentValueIndex];
                elapsedTimeNumber = 0f;
                currentValueIndex++;
                if(currentValueIndex >= currentBlock.vitalValue.Length)
                {
                    currentValueIndex = 0;
                    currentBlockIndex++;
                }
            }
            if (currentValueIndex > 0)
            {
                prevValue = currentValueIndex-1;
            }
            // Play different animations based on conditions
            if (currentBlock.vitalValue[currentValueIndex] > currentBlock.vitalValue[prevValue])
            {
                if (ExperimentSequenceSingleton.hr1Block1Start >= 100 && ExperimentSequenceSingleton.hr1Block1Start < 121)
                {
                    anim.Play("hrNormalToHigh");
                 
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 121)
                {
                    anim.Play("hrHighToVeryHigh");
                    
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start > 44 && ExperimentSequenceSingleton.hr1Block1Start <= 59)
                {
                    anim.Play("hrReturnLowToNormal");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 44)
                {
                    anim.Play("hrReturnVeryLowToLow");
                }
                previousTrend = "increase";

            }
            else if (currentBlock.vitalValue[currentValueIndex] < currentBlock.vitalValue[prevValue])
            {
                if (ExperimentSequenceSingleton.hr1Block1Start <= 59 && ExperimentSequenceSingleton.hr1Block1Start > 44)
                {
                    anim.Play("hrNormalToLow");
                    
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 44)
                {
                    anim.Play("hrLowToVeryLow");
                    
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 100 && ExperimentSequenceSingleton.hr1Block1Start < 121)
                {
                    anim.Play("hrReturnHighToNormal");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 121)
                {
                    anim.Play("hrReturnVeryHighToHigh");
                }
                previousTrend = "decrease";

            }
            else if (currentBlock.vitalValue[currentValueIndex] == currentBlock.vitalValue[prevValue])
            {
                if (ExperimentSequenceSingleton.hr1Block1Start > 59 && ExperimentSequenceSingleton.hr1Block1Start < 100)
                {
                    anim.Play("justMove");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 121)
                {
                    anim.Play("hrStaticHighToVeryHigh");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 44)
                {
                    anim.Play("hrStaticLowToVeryLow");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 59 && ExperimentSequenceSingleton.hr1Block1Start > 44)
                {
                    if (previousTrend.Contains("increase"))
                    {
                        anim.Play("hrStaticVeryLowToLow");
                    }
                    else
                    {
                        anim.Play("hrStaticNormalToLow");
                    }
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 100 && ExperimentSequenceSingleton.hr1Block1Start < 121)
                {
                    if (previousTrend.Contains("decrease"))
                    {
                        anim.Play("hrStaticVeryHighToHigh");
                    }
                    else
                    {
                        anim.Play("hrStaticNormalToHigh");
                    }
                }

            }
            textHr.text = "HR: " + ExperimentSequenceSingleton.hr1Block1Start;
            elapsedTimeNumber += Time.deltaTime;
        }
    }
    /*void Update()
    {
        // Check if there are blocks left
        if (currentBlockIndex < testArray.Length)
        {
            Block item = testArray[currentBlockIndex];
            float duration = item.duration[currentValueIndex];

            // Check if the current value change has finished
            if (elapsedTime >= duration)
            {
                // Move to the next value change
                currentValueIndex++;
                elapsedTime = 0.0f;
                alarmLogged = false;

                // Check if all value changes in the current block have finished
                if (currentValueIndex >= item.valueChange.Length)
                {
                    // Move to the next block
                    currentBlockIndex++;
                    currentValueIndex = 0;
                }
            }

            // Play different animations based on conditions
            if (item.valueChange[currentValueIndex].Contains("increase"))
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    ExperimentSequenceSingleton.hr1Block1Start++;
                    elapsedTimeNumber = 0.0f;
                }
                if (ExperimentSequenceSingleton.hr1Block1Start >= 100 && ExperimentSequenceSingleton.hr1Block1Start < 121)
                {
                    anim.Play("hrNormalToHigh");
                    LogTimestampOfAlarm();
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 121)
                {
                    anim.Play("hrHighToVeryHigh");
                    LogTimestampOfAlarm();
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start > 44 && ExperimentSequenceSingleton.hr1Block1Start <= 59)
                {
                    anim.Play("hrReturnLowToNormal");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 44)
                {
                    anim.Play("hrReturnVeryLowToLow");
                }
                previousTrend = "increase";
                
            }
            else if (item.valueChange[currentValueIndex].Contains("decrease"))
            {
                if (ExperimentSequenceSingleton.hr1Block1Start <= 102 && ExperimentSequenceSingleton.hr1Block1Start > 84)
                {
                    anim.Play("hrNormalToLow");
                    LogTimestampOfAlarm();
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 44)
                {
                    anim.Play("hrLowToVeryLow");
                    LogTimestampOfAlarm();
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 100 && ExperimentSequenceSingleton.hr1Block1Start < 121)
                {
                    anim.Play("hrReturnHighToNormal");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 121)
                {
                    anim.Play("hrReturnVeryHighToHigh");
                }
                previousTrend = "decrease";
                
            }
            else if (item.valueChange[currentValueIndex].Contains("static"))
            {
                if (ExperimentSequenceSingleton.hr1Block1Start > 59 && ExperimentSequenceSingleton.hr1Block1Start < 100)
                {
                    anim.Play("justMove");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 121)
                {
                    anim.Play("hrStaticHighToVeryHigh");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 44)
                {
                    anim.Play("hrStaticLowToVeryLow");
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start <= 59 && ExperimentSequenceSingleton.hr1Block1Start > 44)
                {
                    if (previousTrend.Contains("increase"))
                    {
                        anim.Play("hrStaticVeryLowToLow");
                    }
                    else
                    {
                        anim.Play("hrStaticNormalToLow");
                    }
                }
                else if (ExperimentSequenceSingleton.hr1Block1Start >= 100 && ExperimentSequenceSingleton.hr1Block1Start < 121)
                {
                    if (previousTrend.Contains("decrease"))
                    {
                        anim.Play("hrStaticVeryHighToHigh");
                    }
                    else
                    {
                        anim.Play("hrStaticNormalToHigh");
                    }
                }
               
            }

            // Update the HR value text
            textHr.text = item.valueChange[currentValueIndex] + "\ndur: " + duration.ToString();

            // Increment elapsed time
            elapsedTime += Time.deltaTime;
            elapsedTimeNumber += Time.deltaTime;
        }

        // Reset animation speed
        anim.speed = 1.0f;
    }*/

    void LogTimestampOfAlarm()
    {
        if (!alarmLogged)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Block item = testArray[currentBlockIndex];
            Debug.Log("Alarm triggered at: " + timestamp);
            alarmLogged = true;

            // Append the timestamp to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("hr1 alarm "+ " duration " +item.duration[currentValueIndex] + " "+timestamp);
            }
        }
    }


    IEnumerator PlayAnimations()
    {
        Block[] testArray = ExperimentSequenceSingleton.expSeq;
        foreach (Block item in testArray)
        {
            for (int i = 0; i < item.valueChange.Length; i++)
            {
                float elapsedTime = 0f;
                float duration = item.duration[i];

                while (elapsedTime < duration)
                {
                    anim.speed = 0.3f;
                    elapsedTime += Time.deltaTime;
                    textHr.text = item.valueChange[i] + "\ndur: " +
                        duration.ToString();

                    // Play different animations based on conditions
                    if (item.valueChange[i].Contains("increase"))
                    {
                        anim.Play("hrHighToVeryHigh");
                    }
                    else if (item.valueChange[i].Contains("decrease"))
                    {
                        anim.Play("hrNormalToLow");
                    }
                    else if (item.valueChange[i].Contains("static"))
                    {
                        anim.Play("justMove");
                    }

                    yield return null; // Wait for the next frame
                }

                // Reset animation speed
                anim.speed = 1f;
            }
        }
    }
    /*void Update()
    {
        Block[] testArray = ExperimentSequenceSingleton.expSeq;
        
        foreach (Block item in testArray)
        {
            elapsedTime = 0f;
            for (int i = 0; i < item.valueChange.Length; i++)
            {
                Debug.Log("val: dur " + item.valueChange[i] + " "+ item.duration[i]);
                while (elapsedTime < item.duration[i])
                {
                    anim.speed = 0.3f;
                    elapsedTime = elapsedTime + Time.deltaTime;
                    textHr.text = item.valueChange[i] + " \nd" +
                        item.duration[i].ToString()+"\nel"+elapsedTime.ToString();

                    if (item.valueChange[i].Contains("increase"))
                    {
                        anim.Play("hrNormalToHigh");
                    }
                    else if (item.valueChange[i].Contains("decrease"))
                    {
                        anim.Play("hrNormalToLow");
                    }
                    else if (item.valueChange[i].Contains("static"))
                    {
                        anim.Play("justMove");
                    }
                }
               
                elapsedTime = 0f;

             

            }
            
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class oBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textO2;
    private float updateTime = 2f;
    private float elapsedTimeNumber = 0f;
    O21Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";
    void Start()
    {
        anim = GetComponent<Animator>();
        testArray = O21ExperimentSequence.expSeq;
        textO2.enabled = false;
        //StartCoroutine(PlayAnimations());

    }

    private void Update()
    {
        if (CommonPrototypeVariables.isExperimentStarted)
        {
            if (currentBlockIndex < testArray.Length)
            {
                O21Block item = testArray[currentBlockIndex];
                float duration = item.duration[currentValueIndex];

                // Check if the current value change has finished
                if (elapsedTime >= duration)
                {
                    // Move to the next value change
                    currentValueIndex++;
                    elapsedTime = 0.0f;

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
                        O21ExperimentSequence.o21Block1Start++;
                        elapsedTimeNumber = 0.0f;
                    }
                    if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                    {
                        anim.Play("o2ReturnLowToNormal");
                    }
                    else if (O21ExperimentSequence.o21Block1Start <= 89)
                    {
                        anim.Play("o2ReturnVeryLowToLow");
                    }
                    previousTrend = "increase";

                }
                else if (item.valueChange[currentValueIndex].Contains("decrease"))
                {
                    if (elapsedTimeNumber >= updateTime)
                    {
                        O21ExperimentSequence.o21Block1Start--;
                        elapsedTimeNumber = 0.0f;
                    }
                    if (O21ExperimentSequence.o21Block1Start >= 90 && O21ExperimentSequence.o21Block1Start <= 95)
                    {
                        anim.Play("o2NormalToLow");
                    }
                    else if (O21ExperimentSequence.o21Block1Start <= 89)
                    {
                        anim.Play("o2LowToVeryLow");
                    }
                    previousTrend = "decrease";

                }
                else if (item.valueChange[currentValueIndex].Contains("static"))
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

                // Update the O2 value text
                textO2.text = "o2: " + O21ExperimentSequence.o21Block1Start.ToString();

                // Increment elapsed time
                elapsedTime += Time.deltaTime;
                elapsedTimeNumber += Time.deltaTime;
            }

            // Reset animation speed
            anim.speed = 1.0f;
        }
    }

}

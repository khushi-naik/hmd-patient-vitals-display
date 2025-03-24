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
                    int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    int currentVital = currentBlock.vitalValue[currentValueIndex];
                    if (currentVital > previousVital)
                    {
                        if (currentVital >= 138 && currentVital < 156)
                        {
                            anim.speed = 1.0f;
                            anim.Play("highAnim");
                            if (!alarmLog[currentBlockIndex])
                            {
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
                        else if (Bp1ExperimentSequence.bp1Block1Start > 84 && Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            //anim.Play("lowToNormal");
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                       
                        previousTrend = "increase";
                    }
                    else if (currentVital < previousVital)
                    {
                        if (currentVital <= 102 && currentVital > 84)
                        {
                            anim.speed = 1.0f;
                            anim.Play("lowAnim");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        
                        else if (currentVital > 102 && currentVital < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138 && Bp1ExperimentSequence.bp1Block1Start < 156)
                        {
                            anim.speed = 0.5f;
                            //anim.Play("highToNormal");
                            anim.Play("justMove");
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
                       
                      
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102 && Bp1ExperimentSequence.bp1Block1Start > 84)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            if (previousTrend.Contains("increase"))
                            {
                                //anim.Play("staticVeryLowToLowAnim");
                            }
                            else
                            {
                                //anim.Play("staticNormalToLowAnim");
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138 && Bp1ExperimentSequence.bp1Block1Start < 156)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMove");
                            if (previousTrend.Contains("decrease"))
                            {
                                //anim.Play("staticVeryHighToHighAnim");
                            }
                            else
                            {
                                //anim.Play("staticNormalToHighAnim");
                            }
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

    /*public Camera mainCamera;
    private float speed = 0.3f;
    //private float animationTimer = 0f;
    Vector3 edgePosition;
    //private float elapsedTime = 0f;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    private string animType = "";
    private int currentBlockIndex = 0;
    private int currentValueIndex = 0;
    private BpBlock2[] expArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;

    private Vector3 startPosition;
    private float moveProgress = 0f;

    void Start()
    {
        expArray = BP2ExperimentSequence.BpExperimentBlock2;
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.5f, 0.9f));
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
            BpBlock2 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    //reset animation variables
                    moveProgress = 0f;
                    animType = "";
                    transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.5f, 0.9f));
                    startPosition = transform.position;
                    transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);

                    int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    int currentVital = currentBlock.vitalValue[currentValueIndex];
                    if (currentVital > previousVital)
                    {
                        if (currentVital >= 138 && currentVital < 156)
                        {
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP2, normal to high_blockno" + currentBlockIndex + "_curval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;

                            }
                            animType = "highAnim";

                        }
                        
                    }
                    else if (currentVital < previousVital)
                    {
                        //lowAnim
                    }
                    else if (currentVital == previousVital)
                    {
                       
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
                    Color startColor = new Color(1.0f, 0.6f, 0.6f, 1.0f);
                    Color targetColor = new Color(1.0f, 0.4f, 0.4f, 1.0f);
                    objRenderer.material.color = Color.Lerp(startColor, targetColor, moveProgress);

                    Vector3 startScale = new Vector3(0.025f, 0.025f, 0.025f);

                    if (animType.Equals("lowAnim"))
                    {
                        moveProgress += Time.deltaTime * speed;
                        //move animation-backward
                        Vector3 currentPosition = transform.position;
                        Vector3 targetPosition = startPosition + (directionToCamera * -0.2f);
                        transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
                        //scale animation
                        Vector3 targetScale = new Vector3(0.005f, 0.005f, 0.005f); // Larger scale (1.5x)
                        transform.localScale = Vector3.Lerp(startScale, targetScale, moveProgress);
                    }
                    else if (animType.Equals("highAnim"))
                    {
                        moveProgress += Time.deltaTime * speed;
                        //move animation-forward
                        Vector3 currentPosition = transform.position;
                        Vector3 targetPosition = startPosition + (directionToCamera * 0.2f);
                        transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
                        //scale animation
                        Vector3 targetScale = new Vector3(0.05f, 0.05f, 0.05f); // Larger scale (1.5x)
                        transform.localScale = Vector3.Lerp(startScale, targetScale, moveProgress);
                    }
                    else
                    {
                        transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.5f, 0.9f));
                    }
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System;

public class StartExperimentSceneScript : MonoBehaviour
{
    public TextMeshProUGUI testing;
    public TextMeshProUGUI probeAlertText;
    public TextMeshProUGUI consoleObject;
    private Coroutine experimentCountdownCoroutine;
    private TcpConnectionScript tcpObj;

    void Start()
    {
        probeAlertText.enabled = false; //keep alert hidden till a probe occurs
        GameObject obj = GameObject.Find("testTCP");
        if (obj != null)
        {
            tcpObj = obj.GetComponent<TcpConnectionScript>();
        }
    }

    public void OnSelectEntered(SelectEnterEventArgs _)
    {
        testing.text = "started";
        if(experimentCountdownCoroutine != null)
        {
            StopCoroutine(experimentCountdownCoroutine);
            experimentCountdownCoroutine = null;
        }
        experimentCountdownCoroutine = StartCoroutine(countDownFunction());
        //gameObject.SetActive(false);
        //set global variable to start experiment sequence


    }

    IEnumerator countDownFunction()
    {
        testing.text = "starting in 4";
        yield return new WaitForSeconds(1);
        testing.text = "starting in 3";
        yield return new WaitForSeconds(1);
        testing.text = "starting in 2";
        yield return new WaitForSeconds(1);
        testing.text = "starting in 1";
        yield return new WaitForSeconds(1);

        CommonPrototypeVariables.isExperimentStarted = true;
        tcpObj.sendMessage("expA1 started at," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        experimentCountdownCoroutine = null;
        consoleObject.enabled = false;
        gameObject.SetActive(false);

    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

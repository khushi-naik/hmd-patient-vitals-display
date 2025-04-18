using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class StartExperimentSceneScript : MonoBehaviour
{
    public TextMeshProUGUI testing;
    public TextMeshProUGUI probeAlertText;
    public TextMeshProUGUI consoleObject;
    private Coroutine experimentCountdownCoroutine;

    void Start()
    {
        probeAlertText.enabled = false; //keep alert hidden till a probe occurs
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
        experimentCountdownCoroutine = null;
        consoleObject.enabled = false;
        gameObject.SetActive(false);

    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

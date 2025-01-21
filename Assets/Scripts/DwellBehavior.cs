using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DwellBehavior : MonoBehaviour
{

    [Tooltip("hr Text")]
    [SerializeField]
    private TextMeshProUGUI textHr;

    [Tooltip("bp Text")]
    [SerializeField]
    private TextMeshProUGUI textBp;

    [Tooltip("o2 Text")]
    [SerializeField]
    private TextMeshProUGUI textO2;

    public TextMeshProUGUI conObj;

    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        textHr.enabled = false;
        textHr.GetComponent<BoxCollider>().enabled = false;
        textBp.enabled = false;
        textO2.enabled = false;
    }

    public void OnSelectEntered(SelectEnterEventArgs _)
    {
        //material.color = onSelectColor;
        //textDesc.SetActive(true);
        textHr.enabled = true;
        textHr.text = "HR: 60";

        textBp.enabled = true;
        textBp.text = "BP: " + Bp1ExperimentSequence.bp1Block1Start.ToString();

        textO2.enabled = true;
        textO2.text = "O2: " + O21ExperimentSequence.o21Block1Start.ToString();

        textHr.GetComponent<BoxCollider>().enabled = true;
        conObj.text = "activated";
    }

    /*public void OnSelectEntered(SelectEnterEventArgs _)
    {
        //material.color = onSelectColor;
        //textDesc.SetActive(true);
        textHr.enabled = true;
        textHr.text = "HR: 60";

        textBp.enabled = true;
        textBp.text = "BP: "+ Bp1ExperimentSequence.bp1Block1Start.ToString();

        textO2.enabled = true;
        textO2.text = "O2: "+ O21ExperimentSequence.o21Block1Start.ToString();


    }*/

    /// <summary>
    /// Triggered when the attached <see cref="StatefulInteractable"/> is de-selected.
    /// </summary>
    public void OnSelectExited(SelectExitEventArgs _)
    {
        textHr.enabled = false;
        textBp.enabled = false;
        textO2.enabled = false;
        //material.color = idleStateColor;
        //textDesc.SetActive(false);
        //textDesc.text = "not anymore";
    }
}


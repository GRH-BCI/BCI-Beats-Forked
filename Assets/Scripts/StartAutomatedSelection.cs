using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BCIEssentials.Controllers;
using UnityEngine.UI;

public class StartAutomatedSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject controllerManager;
    [SerializeField]
    private BCIController bciController;
    [SerializeField]
    private Button play_button;
    private void Awake()
    {
        if (bciController == null)
        {
            controllerManager = GameObject.FindGameObjectWithTag("ControllerManager");
            bciController = controllerManager.GetComponent<BCIController>();
            StartCoroutine(InitCoroutine());
        }
    }

    public void StartSelection()
    {
        // this runs p300 selection automatically. We will turn it off for now.
        //bciController.ActiveBehavior.StartStopStimulusRun();
    }

    private IEnumerator InitCoroutine()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("Going to assign the value now to bciController for Start Training Button");
        //bciController = GameObject.FindGameObjectWithTag("ControllerManager").GetComponent<BCIController>();
        bciController = controllerManager.GetComponent<BCIController>();

        StartSelection();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BCIEssentials.Controllers;

public class StartAutomatedSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject controllerManager;
    [SerializeField]
    private BCIController bciController;
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
        bciController.ActiveBehavior.StartStopStimulusRun();
        Debug.Log("done");
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

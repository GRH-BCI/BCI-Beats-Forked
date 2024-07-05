using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BCIEssentials.Controllers;

public class StartAutomatedTraining : MonoBehaviour
{
    [SerializeField]
    private GameObject controllerManager;
    [SerializeField]
    private BCIController bciController;
    private void Awake()
    {
        if (bciController == null)
        {
            //bciController = GameObject.FindGameObjectWithTag("ControllerManager").GetComponent<BCIController>();
            controllerManager = GameObject.FindGameObjectWithTag("ControllerManager");
            bciController = controllerManager.GetComponent<BCIController>();
            Debug.Log("No BCI Controller Found. Assigning one now.");
            StartCoroutine(InitCoroutine());
        }
    }

    public void StartAutoTraining()
    {
        bciController.ActiveBehavior.StartTraining(BCITrainingType.Automated);
        Debug.Log("done");
    }

    private IEnumerator InitCoroutine()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("Going to assign the value now to bciController for Start Training Button");
        //bciController = GameObject.FindGameObjectWithTag("ControllerManager").GetComponent<BCIController>();
        bciController = controllerManager.GetComponent<BCIController>();
    }
}

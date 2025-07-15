using System;
using System.Collections;
using UnityEngine;

public class AffectedByCamera : CameraListener
{
    public CameraAction[] actions;
    int index;
    bool doingSomething;

    public static void DoAction(CameraAction action)
    {
        switch (action.action)
        {
            case CameraAction.CameraFunction.Activate:
                action.affectedObject.SetActive(true);
                break;
            case CameraAction.CameraFunction.DeActivate:
                action.affectedObject.SetActive(false);
                break;
            case CameraAction.CameraFunction.Destroy:
                Destroy(action.affectedObject);
                break;
            case CameraAction.CameraFunction.MakeTallyHallReference:
                RenderSettings.fog = true;
                RenderSettings.ambientSkyColor = Color.black;
                SpawnPointManger.instance.count = true;
                break;
            case CameraAction.CameraFunction.CallBBGirl:
                break;
        }
    }
    
    public override void OnTakePicture()
    {
        if (doingSomething) return;
        StartCoroutine(DoThing());
    }

    public IEnumerator DoThing()
    {
        doingSomething = true;
        bool keepGoing = false;
        do
        {
            if (index == actions.Length)
                break;
            DoAction(actions[index]);
            keepGoing = actions[index].continueToNextAction;
            if (actions[index].action == CameraAction.CameraFunction.Jump)
                index = actions[index].jumpTo - 1;
            if (actions[index].waitFor > 0)
                yield return new WaitForSeconds(actions[index].waitFor);
            index++;

        } while (keepGoing);

        doingSomething = false;
    }
}

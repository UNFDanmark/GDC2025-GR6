using UnityEngine;

public class AffectedByCamera : CameraListener
{
    public CameraAction[] actions;
    int index;

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
        }
    }
    
    public override void OnTakePicture()
    {
        bool keepGoing = false;
        do
        {
            if (index == actions.Length)
                break;
            DoAction(actions[index]);
            keepGoing = actions[index].continueToNextAction;
            if (actions[index].action == CameraAction.CameraFunction.Jump)
                index = actions[index].jumpTo - 1;
            index++;

        } while (keepGoing);
    }
}

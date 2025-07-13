using UnityEngine;

public class AffectedByCamera : CameraListener
{
    public CameraAction[] actions;

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
}

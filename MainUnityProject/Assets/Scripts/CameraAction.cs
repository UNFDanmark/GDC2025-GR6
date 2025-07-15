using UnityEngine;

[System.Serializable]
public class CameraAction
{
    public enum CameraFunction { Destroy, Activate, DeActivate, Jump, MakeTallyHallReference }

    public int jumpTo = -1;
    public bool continueToNextAction;
    public GameObject affectedObject;
    public CameraFunction action;
}

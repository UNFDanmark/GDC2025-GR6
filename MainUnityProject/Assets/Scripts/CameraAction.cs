using UnityEngine;

[System.Serializable]
public class CameraAction
{
    public enum CameraFunction { Destroy, Activate, DeActivate, Jump, MakeTallyHallReference, CallBBGrl, JingleJangle, JingleJangleTheJonglerReturns }

    public int jumpTo = -1;
    public float waitFor;
    public bool continueToNextAction;
    public GameObject affectedObject;
    public CameraFunction action;
}

using UnityEngine;

[System.Serializable]
public class CameraAction
{
    public enum CameraFunction { Destroy, Activate, DeActivate }
    
    public bool continueToNextAction;
    public GameObject affectedObject;
    public CameraFunction action;
}

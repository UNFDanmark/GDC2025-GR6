using UnityEngine;

public class CameraListener : MonoBehaviour
{
    public bool seen;
    public virtual void OnCouldBeSeen()
    {
        seen = true;
    }

    public virtual void OnResetSeen()
    {
        seen = false;
    }

    public virtual void OnTakePicture()
    {
        
    }
}

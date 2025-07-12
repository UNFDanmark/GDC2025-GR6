using UnityEngine;

public class DestroyOnPicture : CameraListener
{
    public override void OnTakePicture()
    {
        if (seen)
        {
            Destroy(gameObject);
        }
    }
}

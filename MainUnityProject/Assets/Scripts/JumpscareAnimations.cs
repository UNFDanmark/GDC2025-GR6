using UnityEngine;

public class JumpscareAnimations : MonoBehaviour
{
    public void ScreenStatic()
    {
        PlayerMovement.instance.ScreenStatic();
    }

    public void ReDoEverything()
    {
        PlayerMovement.instance.StopScreenStatic();
    }
}

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
        if (MonsterScript.instance.weakened)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Credits scene 2");
        }
    }
}

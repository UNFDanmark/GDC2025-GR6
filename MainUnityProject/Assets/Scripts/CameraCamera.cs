using System.Collections;
using UnityEngine;

public class CameraCamera : MonoBehaviour
{
    public IEnumerator TakePicture()
    {
        yield return null;
        yield return null;
        yield return null;
        
        gameObject.SetActive(false);
    }
}

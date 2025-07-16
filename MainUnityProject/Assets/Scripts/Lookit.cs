using UnityEngine;

public class Lookit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerMovement.instance.playerLook.transform.position);
        transform.Rotate(Vector3.up, 180F);
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAnimator : MonoBehaviour
{
    public InputAction holdButton;
    public Animator animator;
    void Start()
    {
        holdButton.Enable();
    }

    void Update()
    {
        animator.SetBool("Holding", holdButton.IsPressed());
    }
}

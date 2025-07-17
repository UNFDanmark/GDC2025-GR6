using System;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    public GameObject RequirementText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RequirementText.SetActive(true);
        }
        else
        {
            RequirementText.SetActive(false);
        }
    }
}

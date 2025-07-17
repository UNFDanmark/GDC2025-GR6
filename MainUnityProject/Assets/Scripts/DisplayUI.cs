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


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("hi");
            RequirementText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Gooodbye");
            RequirementText.SetActive(false);
        }    }
}

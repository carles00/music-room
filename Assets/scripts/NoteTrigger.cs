using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private Material material;
    private bool hasBlueTarget = false;
    private bool hasRedTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        material = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(string player)
    {
        if (player.Equals("red"))
        {
            Debug.Log("set red target");
            material.color = Color.red;
            hasRedTarget = true;
        }
        else if (player.Equals("blue"))
        {
            material.color = Color.blue;
            hasBlueTarget = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") && hasRedTarget)
        { 
            audioSource.Play(0);
            hasRedTarget = false;
            material.color = Color.white;
        }
        if (other.CompareTag("Player2") && hasBlueTarget)
        {
            audioSource.Play(0);
            hasRedTarget = false;
            material.color = Color.white;
        }
    }

}

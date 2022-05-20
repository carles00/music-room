using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrigger : MonoBehaviour
{
    private ParticleSystem particle;
    private bool hasBlueTarget = false;
    private bool hasRedTarget = false;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ActivateParticle()
    {
        particle.Play();
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
    }
    public void SetTarget(string player)
    {
        if (player.Equals("red"))
        {
            Debug.Log("set red target");
            ActivateParticle();
            hasRedTarget = true;
        }
        else if (player.Equals("blue"))
        {
            ActivateParticle();
            hasBlueTarget = true;
        }

    }
    public bool isActivated()
    {
        return hasBlueTarget || hasRedTarget;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") && hasRedTarget)
        {
            Debug.Log("red player enter");
            hasRedTarget = false;
            particle.Stop();
        }
        if (other.CompareTag("Player2") && hasBlueTarget)
        {
            hasBlueTarget = false;
            particle.Stop();
        }
    }

}

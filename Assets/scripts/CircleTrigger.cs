using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private ParticleSystem particle;
    private bool hasBlueTarget = false;
    private bool hasRedTarget = false;

    private bool hasPurpleTarget = false;
    private bool player1forPurple = false;
    private bool player2forPurple = false;

    private bool ableToPlay = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }
        if (particle == null)
        {
            particle = GetComponent<ParticleSystem>();
            particle.Stop();
        }
    }
    private void ActivateParticle()
    {
        
        particle.Play();
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
        ableToPlay = true;
    }
    public void SetTarget(string player)
    {
        if (player.Equals("red"))
        {
            ActivateParticle();
            hasRedTarget = true;
        }
        else if (player.Equals("blue"))
        {
            ActivateParticle();
            hasBlueTarget = true;
        }
        else if (player.Equals("purple"))
        {
            ActivateParticle();
            hasPurpleTarget = true;
        }

    }
    public bool isActivated()
    {
        return hasBlueTarget || hasRedTarget || hasPurpleTarget;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") && hasRedTarget)
        {
            if(ableToPlay){
                audioSource.Play(0);
                ableToPlay=false;
            }
            hasRedTarget = false;
            particle.Stop();
        }
        if (other.CompareTag("Player2") && hasBlueTarget)
        {
            if(ableToPlay){
                audioSource.Play(0);
                ableToPlay=false;
            }
            hasBlueTarget = false;
            particle.Stop();
        }
        if(other.CompareTag("Player1") && hasPurpleTarget){
            player1forPurple = true;
            
        }
        if(other.CompareTag("Player2") && hasPurpleTarget){
            player2forPurple = true;
        }
        if(player1forPurple && player2forPurple){
            if(ableToPlay){
                audioSource.Play(0);
                ableToPlay=false;
            }
            hasPurpleTarget = false;
            player1forPurple = false;
            player2forPurple = false;

            particle.Stop();
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player1") && hasPurpleTarget){
            player1forPurple = false;
        }
        if(other.CompareTag("Player2") && hasPurpleTarget){
            player2forPurple = false;
        }
    }
}


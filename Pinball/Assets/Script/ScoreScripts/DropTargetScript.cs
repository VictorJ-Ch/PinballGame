using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DropTargetScript : MonoBehaviour
{
    public float dropDistance = 10f;
    public int bankID = 0;
    public float resetDelay = 0.5f;
    public static List<DropTargetScript> dropTargets = new List<DropTargetScript>();
    public int targetValue = 100;
    public int bankValue = 10000;
    private bool isDropped = false;
    //SFX
    private AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip resetSound;

    void Start()
    {
        dropTargets.Add(this);
        //SFX
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isDropped)
        {
            //Drop target
            PlaySound(hitSound); //SFX
            transform.position += Vector3.down * dropDistance;
            isDropped = true;
            ScoreManagerScript.score += targetValue;
            //Check to see if the rest of the bank has been dropped
            bool resetBank = true;
            foreach (DropTargetScript target in dropTargets)
            {
                if (target.bankID == bankID)
                {
                    if (!target.isDropped)
                    {
                        resetBank = false;
                    }
                }
            }
            //Reset all drop targets in the bank if the bank has been dropped
            if (resetBank)
            {
                ScoreManagerScript.score += bankValue;
                Invoke("ResetBank", resetDelay);
            }
        }
    }

    void ResetBank()
    {
        //SFX
        PlaySound(resetSound);
        foreach (DropTargetScript target in dropTargets)
        {
            if (target.bankID == bankID)
            {
                target.transform.position += Vector3.up * dropDistance;
                target.isDropped = false;
            }
        }
    }

    void PlaySound(AudioClip sound)
    {
        if (sound != null && audioSource != null)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}

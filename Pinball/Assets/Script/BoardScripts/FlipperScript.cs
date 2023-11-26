using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStreght = 10000f;
    public float flipperDamper = 150f;
    private HingeJoint hinge;
    //SFX
    private AudioSource audioSource;
    public AudioClip flipperSound;
    private bool soundPlayed = false;
    //Axes names
    public string inputName;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        //SFX
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = flipperSound;
        audioSource.playOnAwake = false;
    }
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStreght;
        spring.damper = flipperDamper;
        if (Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
            //SFX
            if (!soundPlayed)
            {
                PlayFlipperSound();
            }
        }
        else
        {
            spring.targetPosition = restPosition;
            soundPlayed = false; //Restart SFX
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
    void PlayFlipperSound()
    {
        if (flipperSound != null && audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                soundPlayed = false;
            }
        }
    }
}

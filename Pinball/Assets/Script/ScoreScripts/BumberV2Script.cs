using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BumberV2Script : MonoBehaviour
{
    public float force = 100f;
    public float forceRadius = 1f;
    public int scoreValue = 100;
    //SFX
    public AudioClip collisionSound;
    private AudioSource audioSource;
    //Scale
    public Vector3 scaleChangeAmount = new Vector3(.1f, 0.1f, .1f);
    public float scaleChangeDuration = 0.3f;
    private bool isScaling = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collisionSound;
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {
            if (col.GetComponent<Rigidbody>())
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
            }
        }
        if (collisionSound != null && audioSource != null)
        {
            audioSource.Play();
        }
        ScoreManagerScript.score += scoreValue;
        if (!isScaling)
        {
            StartCoroutine(ScaleBumper());
        }
    }

    IEnumerator ScaleBumper()
    {
        isScaling = true;
        Vector3 originalScale = transform.localScale;
        transform.localScale += scaleChangeAmount;
        yield return new WaitForSeconds(scaleChangeDuration);
        transform.localScale = originalScale;
        isScaling = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BumberV2Script : MonoBehaviour
{
    public float force = 100f;
    public float forceRadius = 1f;
    void OnCollisionEnter()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {
            if (col.GetComponent<Rigidbody>())
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
            }
        }
    }
}

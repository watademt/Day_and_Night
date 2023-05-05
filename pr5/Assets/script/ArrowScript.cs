using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Rigidbody rb;
    private float power = 20f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * power, ForceMode.Impulse);
    }
}

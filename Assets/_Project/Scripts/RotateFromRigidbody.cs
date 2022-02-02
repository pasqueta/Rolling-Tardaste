using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFromRigidbody : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbodyToObserve = null;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-rigidbodyToObserve.angularVelocity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLock : MonoBehaviour
{
   
   
    public Transform target;

    private Vector3 vel = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = -10;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 0);


    }




}

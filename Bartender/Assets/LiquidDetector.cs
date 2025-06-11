using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDetector : MonoBehaviour
{
    private SphereCollider trigger;

    void Start()
    {
        trigger = GetComponent<SphereCollider>();
        trigger.isTrigger = true;
    }
}

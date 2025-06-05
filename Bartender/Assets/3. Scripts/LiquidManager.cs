using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidManager : MonoBehaviour
{
    [SerializeField] private LiquidData liquidData;
    [SerializeField] private GameObject liquidObject;
    [SerializeField][Range(0f, 1f)] private float remainValue = 1f;
    [SerializeField][Range(-18f, 27f)] private float liquidTemperature = -18f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

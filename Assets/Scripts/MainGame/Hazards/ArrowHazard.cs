using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHazard : MonoBehaviour
{
    public GameObject arrowPrefab;
    [SerializeField] float shootInterval;
    private float shootIntervalLeft;
    
    /* removed unnecessary unused awake */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootIntervalLeft = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootIntervalLeft -= Time.deltaTime;
        if (shootIntervalLeft <= 0)
        {
            //TODO: make object pooling
            ArrowObject arrow = Instantiate(arrowPrefab,transform.position,Quaternion.identity).GetComponent<ArrowObject>();
            arrow.transform.Rotate(0, 180, 0); //redundant double 90 degree rotation changed it to only one of 180 degrees
            shootIntervalLeft = shootInterval;
        }
    }
}
using Unity.Mathematics;
using UnityEngine;

public class ArrowHazard : MonoBehaviour
{
    [SerializeField] private ArrowPooler arrowPooler;
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
            GameObject arrow = arrowPooler.SpawnFromPool(transform.position, quaternion.identity);
            arrow.transform.Rotate(0, 180, 0); //redundant double 90 degree rotation changed it to only one of 180 degrees
            shootIntervalLeft = shootInterval;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class ArrowPooler : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] private int size;

    private Queue<GameObject> _pool = new Queue<GameObject>();
    
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject newArrow = Instantiate(arrowPrefab, transform, true);
            newArrow.SetActive(false);

            _pool.Enqueue(newArrow);
        }
    }

    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject spawnedArrow = _pool.Dequeue();

        spawnedArrow.transform.position = position;
        spawnedArrow.transform.rotation = rotation;
        
        spawnedArrow.SetActive(true);

        _pool.Enqueue(spawnedArrow);
        return spawnedArrow;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesSpawner : MonoBehaviour
{
    [SerializeField] GameObject Prefab;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 10));
            Instantiate(Prefab, new Vector3(Random.Range(-100f, 100f), 5, Random.Range(-100f, 100f)), Quaternion.identity);
        }
    }
}

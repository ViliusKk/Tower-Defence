using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int count = 10;
    public float cooldown = 0.5f;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
}

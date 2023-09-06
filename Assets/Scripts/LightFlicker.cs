using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource;
    public float min,max;

    void Start()
    {
        StartCoroutine(Flicker());
    }
    IEnumerator Flicker()
    {
        lightSource.enabled = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(min,max));
        lightSource.enabled = false;
        yield return new WaitForSeconds(UnityEngine.Random.Range(min, max));
        StartCoroutine(Flicker());
    }
    void OnDisable()
    {
        lightSource.enabled = false;
    }
}

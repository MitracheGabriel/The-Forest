using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public GameObject CoinsCollectScript;
    public AudioSource CoinAudio;
    void OnTriggerEnter(Collider col)
    {
        Destroy(this.gameObject);
        CoinsCollectScript.GetComponent<CoinSystem>().CollectedCoins += 1;
        CoinAudio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject ChestSwing;
    public GameObject chestText;

    void OnMouseOver()
    {
        if (Input.GetButton("Interact"))
        {
            GetComponent<BoxCollider>().enabled = false;
            ChestSwing.GetComponent<Animation>().Play("ChestOpenAnim");
            StartCoroutine(ChestText());
        }
    }
    IEnumerator ChestText()
    {
        yield return new WaitForSeconds(1);
        chestText.SetActive(true);
        GlobalCash.CurrentCoins += 10;
        yield return new WaitForSeconds(4);
        chestText.SetActive(false);
        
    }
}

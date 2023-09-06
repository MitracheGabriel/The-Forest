using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalCash : MonoBehaviour
{
    public static int CurrentCoins = 100;
    public int LocalCoins;
    public GameObject InventoryDisplay;
    public GameObject ShopDisplay;


    void Update()
    {
        LocalCoins = CurrentCoins;
        InventoryDisplay.GetComponent<TextMeshProUGUI>().text = "Coins: " + LocalCoins;
        ShopDisplay.GetComponent<TextMeshProUGUI>().text = "Coins: " + LocalCoins;
    }
}

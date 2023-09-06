using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using TMPro;

public class Shop01Access : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject ShopInventory;

    public GameObject Item01Text;
    public GameObject Item02Text;
    public GameObject Item03Text;
    public GameObject Item04Text;

    public GameObject Item01Price;
    public GameObject Item02Price;
    public GameObject Item03Price;
    public GameObject Item04Price;

    public GameObject ItemCompletion;
    public GameObject CompleteText;

    public float TheDistance = 999f;
    public int ItemPurchaseNumber;
    public GameObject NotEnough;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 3 && Input.GetButtonDown("Interact"))
        {
            ShopInventory.SetActive(true);
            ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GlobalShop.ShopNumber = 1;
            GlobalShop.LoadShop(GlobalShop.ShopNumber);
            
            Item01Text.GetComponent<TextMeshProUGUI>().text = "" + GlobalShop.Item01;
            Item02Text.GetComponent<TextMeshProUGUI>().text = "" + GlobalShop.Item02;
            Item03Text.GetComponent<TextMeshProUGUI>().text = "" + GlobalShop.Item03;
            Item04Text.GetComponent<TextMeshProUGUI>().text = "" + GlobalShop.Item04;

            Item01Price.GetComponent<TextMeshProUGUI>().text = "Price: " + GlobalShop.Item01Price;
            Item02Price.GetComponent<TextMeshProUGUI>().text = "Price: " + GlobalShop.Item02Price;
            Item03Price.GetComponent<TextMeshProUGUI>().text = "Price: " + GlobalShop.Item03Price;
            Item04Price.GetComponent<TextMeshProUGUI>().text = "Price: " + GlobalShop.Item04Price;
        }
    }
    public void Item01()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<TextMeshProUGUI>().text = "Are you sure you want to buy " + GlobalShop.Item01 + "?";
        ItemPurchaseNumber = 1;
        NotEnough.SetActive(false);
    }
    public void Item02()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<TextMeshProUGUI>().text = "Are you sure you want to buy " + GlobalShop.Item02 + "?";
        ItemPurchaseNumber = 2;
        NotEnough.SetActive(false);
    }
    public void Item03()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<TextMeshProUGUI>().text = "Are you sure you want to buy " + GlobalShop.Item03 + "?";
        ItemPurchaseNumber = 3;
        NotEnough.SetActive(false);
    }
    public void Item04()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<TextMeshProUGUI>().text = "Are you sure you want to buy " + GlobalShop.Item04 + "?";
        ItemPurchaseNumber = 4;
        NotEnough.SetActive(false);
    }
    public void CancelTransaction()
    {
        ItemCompletion.SetActive(false);
        ItemPurchaseNumber = 0;
        NotEnough.SetActive(false);
    }  
    public void CompleteTransaction()
    {
        switch (ItemPurchaseNumber)
        {
            case 1:
                if (GlobalCash.CurrentCoins >= GlobalShop.Item01Price)
                {
                    GlobalCash.CurrentCoins -= GlobalShop.Item01Price;
                    ItemCompletion.SetActive(false);
                }
                else
                {
                    NotEnough.SetActive(true);
                }
                break;
            case 2:
                if (GlobalCash.CurrentCoins >= GlobalShop.Item02Price)
                {
                    GlobalCash.CurrentCoins -= GlobalShop.Item02Price;
                    ItemCompletion.SetActive(false);
                }
                else
                {
                    NotEnough.SetActive(true);
                }
                break;
            case 3:
                if (GlobalCash.CurrentCoins >= GlobalShop.Item03Price)
                {
                    GlobalCash.CurrentCoins -= GlobalShop.Item03Price;
                    ItemCompletion.SetActive(false);
                }
                else
                {
                    NotEnough.SetActive(true);
                }
                break;
            case 4:
                if (GlobalCash.CurrentCoins >= GlobalShop.Item04Price)
                {
                    GlobalCash.CurrentCoins -= GlobalShop.Item04Price;
                    ItemCompletion.SetActive(false);
                }
                else
                {
                    NotEnough.SetActive(true);
                }
                break;
        }
    }
    public void CloseShop()
    {
        ItemCompletion.SetActive(false);
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        ShopInventory.SetActive(false);   
    }

}

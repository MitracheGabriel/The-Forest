using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalShop : MonoBehaviour
{
    public static string Item01;
    public static string Item02;
    public static string Item03;
    public static string Item04;

    public static int Item01Price;
    public static int Item02Price;
    public static int Item03Price;
    public static int Item04Price;

    public static int ShopNumber;

    void Update()
    {
        LoadShop(ShopNumber);
    }
    public static void LoadShop(int number)
    {
        if (ShopNumber == 1)
        {
            Item01 = "Wood Block";
            Item02 = "Black Feather";
            Item03 = "Red Potion";
            Item04 = "Blue Potion";
            Item01Price = 10;
            Item02Price = 10;
            Item03Price = 15;
            Item04Price = 20;
        }
        if (ShopNumber == 2)
        {
            Item01 = "Iron Block";
            Item02 = "Black Feather";
            Item03 = "Red Potion";
            Item04 = "";
            Item01Price = 15;
            Item02Price = 10;
            Item03Price = 15;
            Item04Price = 0;
        }
    }
}

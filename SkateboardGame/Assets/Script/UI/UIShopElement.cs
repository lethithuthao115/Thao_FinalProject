using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
    public int id;
    public int cost;
    public Text costTxt;

    public Button purchaseBtn;

    private void Awake()
    {
        purchaseBtn.onClick.AddListener(OnPurchase);
    }

    public void SetData()
    {
        var canPurchase = !DataPlayer.playerData.skateboardList.Contains(id);
        purchaseBtn.enabled = canPurchase;
        if (canPurchase)
        {
            costTxt.text = cost.ToString();
        }
        else
        {
            costTxt.text = "Owned";
        }
    }

    private void OnPurchase()
    {
        bool canPurchase = DataPlayer.playerData.IsEnoughCoin(cost);
        if(canPurchase)
        {
            DataPlayer.AddSkateboard(id);
            SetData();
            DataPlayer.SubCoin(cost);
        }
        else
        {
            Debug.Log("Do not have enough money");
        }
    }
}

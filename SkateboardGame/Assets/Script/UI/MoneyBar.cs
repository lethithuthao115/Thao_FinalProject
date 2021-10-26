using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
    public Text text;

    public void UpdateCoin()
    {
        text.text = DataPlayer.playerData.coin.ToString();
    }


    private void OnEnable()
    {
        DataPlayer.AddListener(UpdateCoin);
        UpdateCoin();
    }

    private void OnDisable()
    {
        DataPlayer.RemoveListener(UpdateCoin);
    }
}

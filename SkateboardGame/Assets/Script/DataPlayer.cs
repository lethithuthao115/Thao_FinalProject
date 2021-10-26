using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DataPlayer
{
    private const string PLAYER_DATA = "player_data";
    public static AllData playerData;

    private static UnityEvent updateCoin = new UnityEvent();
    static DataPlayer()
    {
        playerData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(PLAYER_DATA));

        if (playerData == null)
        {
            playerData = new AllData();
            playerData.skateboardList = new List<int>();
            playerData.currentSkateboard = 1;

            playerData.skateboardList.Add(1);

            playerData.coin = 10000;

            SaveDataPlayer();
        }
    }

    private static void SaveDataPlayer()
    {
        PlayerPrefs.SetString(PLAYER_DATA, JsonUtility.ToJson(playerData));
    }

    public static void AddListener(UnityAction updateView)
    {
        updateCoin?.AddListener(updateView.Invoke);
    }

    public static void RemoveListener(UnityAction updateView)
    {
        updateCoin?.RemoveListener(updateView.Invoke);
    }

    public static void AddSkateboard(int id)
    {
        playerData.AddSkateboard(id);

        SaveDataPlayer();
    }

    public static void AddCoin(int coin)
    {
        playerData.AddCoin(coin);
        //updateCoin?.Invoke();

        SaveDataPlayer();
    }

    public static void SubCoin(int coin)
    {
        playerData.SubCoin(coin);
        updateCoin?.Invoke();

        SaveDataPlayer();
    }

    public static int GetCurrentSkateboardId()
    {
        return playerData.currentSkateboard;
    }

    public static int GetPrevSkateboard()
    {
        return playerData.GetPrevSkateboard();
    }

    public static int GetNextSkateboard()
    {
        return playerData.GetNextSkateboard();
    }

    public static bool IsEnoughMoney(int price)
    {
        return playerData.IsEnoughCoin(price);
    }
}

public class AllData
{
    public List<int> skateboardList;
    public int currentSkateboard;
    public int coin;
    public void AddSkateboard(int id)
    {
        if (!skateboardList.Contains(id))
        {
            skateboardList.Add(id);
        }
    }

    public void AddCoin(int coin)
    {
        this.coin += coin;
    }

    public void SubCoin(int coin)
    {
        this.coin -= coin;
    }

    public int GetPrevSkateboard()
    {
        var kartId = 1;
        var index = skateboardList.IndexOf(currentSkateboard);

        if (index == 0)
            kartId = skateboardList[skateboardList.Count - 1];
        else
            kartId = skateboardList[index - 1];

        currentSkateboard = kartId;
        return currentSkateboard;
    }

    public int GetNextSkateboard()
    {
        var kartId = 1;
        var index = skateboardList.IndexOf(currentSkateboard);

        if (index == skateboardList.Count - 1)
            kartId = skateboardList[0];
        else
            kartId = skateboardList[index + 1];

        currentSkateboard = kartId;
        return currentSkateboard;
    }

    public bool IsEnoughCoin(int price)
    {
        return (coin >= price);
    }
}
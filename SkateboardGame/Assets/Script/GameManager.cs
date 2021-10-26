using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;

    [SerializeField]
    private int _totalItem;

    public UnityEvent<int> UpdateScore = new UnityEvent<int>();

    public void SetNumberItem()
    {
        _totalItem = FindObjectsOfType<Item>().Length;
    }

    public void CollectItem(int score)
    {
        this._score += score;

        UpdateScore?.Invoke(this._score);

        print("Current Score: " + this._score);

        _totalItem--;

        if (_totalItem == 0)
        {
            print("Win Game");
            Invoke(nameof(EndGame), 2);
        }

        DataPlayer.AddCoin(100);
    }

    void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        //gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;

    [SerializeField]
    private int _totalItem;

    [SerializeField]
    ObjectiveManager m_ObjectiveManager;

    public UnityEvent<int> UpdateScore = new UnityEvent<int>();

    public void SetNumberItem()
    {
        m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
        _totalItem = FindObjectsOfType<Item>().Length;
    }

    public void CollectItem(int score)
    {
        this._score += score;

        UpdateScore?.Invoke(this._score);

        //print("Current Score: " + this._score);

        DataPlayer.AddCoin(100);
    }

    void EndGame(bool isWin)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_ObjectiveManager && m_ObjectiveManager.AreAllObjectivesCompleted())
        {
            EndGame(true);
        }
                 

        //if (m_TimeManager.IsFinite && m_TimeManager.IsOver)
        //    EndGame(false);
    }
}

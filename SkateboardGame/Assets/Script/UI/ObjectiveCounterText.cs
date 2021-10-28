using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ObjectiveCounterText : MonoBehaviour
{
    private Text textScore;

    private void Awake()
    {
        textScore = GetComponent<Text>();
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        UpdateScore(0);
    }

    private void UpdateScore(int score)
    {
        print($"Score: {score} => {name}");
        textScore.text = $"Score: {score}";
    }

    private void OnDisable()
    {
        
    }
}

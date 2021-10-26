using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField] private int _score;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectItem(_score);

            Destroy(gameObject);
        }
    }
}


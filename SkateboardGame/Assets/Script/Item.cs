using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private ParticleSystem ps;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectItem(_score);
            if(ps)
            {
                ps.Play();
            }
            gameObject.SetActive(false);
        }
    }
}


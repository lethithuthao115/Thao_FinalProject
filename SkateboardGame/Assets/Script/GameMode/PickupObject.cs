using UnityEngine;

public class PickupObject : TargetObject
{

    void Start()
    {
        Register();
    }

    void OnCollect()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollect();
        }
    }
}

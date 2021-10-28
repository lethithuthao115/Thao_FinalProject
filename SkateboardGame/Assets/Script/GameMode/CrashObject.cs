using UnityEngine;

public class CrashObject : TargetObject
{
    public ParticleSystem CollectVFX;
    
    public float destroyDelay = 0.3f;

    [SerializeField] private int _score;

    void Start()
    {        
        Register();
    }

    void OnCollect(Collider other)
    {        
        if (CollectVFX)
        {
            CollectVFX.Play();
        }
        GameManager.Instance.CollectItem(_score);
        Objective.OnUnregisterPickup(this);
        //TimeManager.OnAdjustTime(TimeGained);
        Destroy(this.gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.CompareTag("Player"))
            OnCollect(other);
    }
}

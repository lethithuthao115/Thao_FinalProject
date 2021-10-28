using UnityEngine;

public abstract class TargetObject : MonoBehaviour
{
    public GameMode gameMode;

    public float TimeGained;

    [Tooltip("Layers to trigger with")]
    public LayerMask layerMask;

    [Header("Sounds")]

    [Tooltip("Sound played when be collected")]
    public AudioClip CollectSound;

    [HideInInspector]
    public bool active;

    void OnEnable()
    {
        active = true;
    }

    protected void Register()
    {
        Objective.OnRegisterPickup?.Invoke(this);
    }
}

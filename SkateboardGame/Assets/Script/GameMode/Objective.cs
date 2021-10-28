using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameMode
{
    TimeLimit, Collect
}
public abstract class Objective : MonoBehaviour
{
    [Tooltip("Which game mode are you playing?")]
    public GameMode gameMode;

    protected int m_PickupTotal;
    
    [Tooltip("Whether the objective is required to win or not")]
    public bool isOptional;

    [Tooltip("Delay before the objective becomes visible")]
    public float delayVisible;

    [Header("Requirements")]
    [Tooltip("Does the objective have a time limit?")]
    public bool isTimed;

    [Tooltip("If there is a time limit, how long in secs?")]
    public int totalTimeInSecs;
    public bool isCompleted { get; protected set; }
    public bool isBlocking() => !(isOptional || isCompleted);

    protected ObjectiveHUDManger m_ObjectiveHUDManger;

    public UnityAction<UnityActionUpdateObjective> onUpdateObjective;

    public static Action<TargetObject> OnRegisterPickup;
    public static Action<TargetObject> OnUnregisterPickup;

    private List<TargetObject> pickups = new List<TargetObject>();

    public List<TargetObject> Pickups => pickups;
    public int NumberOfPickupsTotal { get; private set; }
    public int NumberOfPickupsRemaining => Pickups.Count;

    public int NumberOfActivePickupsRemaining()
    {
        int total = 0;
        for (int i = 0; i < Pickups.Count; i++)
        {
            if (Pickups[i].active) total++;
        }

        return total;
    }

    protected abstract void ReachCheckpoint(int remaining);

    void OnEnable()
    {
        OnRegisterPickup += RegisterPickup;
        OnUnregisterPickup += UnregisterPickup;
    }

    protected void Register()
    {
        ObjectiveManager.RegisterObjective(this);

        m_ObjectiveHUDManger = FindObjectOfType<ObjectiveHUDManger>();

        if(m_ObjectiveHUDManger)
        {
            m_ObjectiveHUDManger.RegisterObjective(this);
        }    
        
    }

    public void UpdateObjective(string counterText)
    {
        onUpdateObjective?.Invoke(new UnityActionUpdateObjective(this, false, counterText));
    }

    public void CompleteObjective(string counterText)
    {
        isCompleted = true;
        UpdateObjective(counterText);        
    }

    public virtual string GetUpdatedCounterAmount()
    {
        return "";
    }

    public void RegisterPickup(TargetObject pickup)
    {
        if (pickup.gameMode != gameMode) return;

        Pickups.Add(pickup);

        NumberOfPickupsTotal++;
    }

    public void UnregisterPickup(TargetObject pickupCollected)
    {
        if (pickupCollected.gameMode != gameMode) return;
        
        {
            ReachCheckpoint(NumberOfPickupsRemaining - 1);
            Pickups.Remove(pickupCollected);            
        }
    }

    public void ResetPickups()
    {
        for (int i = 0; i < Pickups.Count; i++)
        {
            Pickups[i].active = true;
        }
    }

    void OnDisable()
    {
        OnRegisterPickup -= RegisterPickup;
        OnUnregisterPickup -= UnregisterPickup;
    }

}
public class UnityActionUpdateObjective
{
    public Objective objective;    
    public bool isComplete;
    public string counterText;

    public UnityActionUpdateObjective(Objective objective, bool isComplete, string counterText)
    {
        this.objective = objective;        
        this.isComplete = isComplete;
        this.counterText = counterText;
    }
}

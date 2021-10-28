using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveReachTarget : Objective
{

    [Tooltip("Choose whether you need to collect all pickups or only a minimum amount")]
    public bool mustCollectAllPickups = true;

    [Tooltip("If MustCollectAllPickups is false, this is the amount of pickups required")]
    public int pickupsToCompleteObjective = 5;
    

    IEnumerator Start()
    {

        //TimeManager.OnSetTime(totalTimeInSecs, isTimed, gameMode);

        yield return new WaitForEndOfFrame();      

        if (mustCollectAllPickups)
            pickupsToCompleteObjective = NumberOfPickupsTotal;

        Register();
    }

    protected override void ReachCheckpoint(int remaining)
    {

        if (isCompleted)
            return;

        if (mustCollectAllPickups)
            pickupsToCompleteObjective = NumberOfPickupsTotal;

        m_PickupTotal = NumberOfPickupsTotal - remaining;
        int targetRemaining = mustCollectAllPickups ? remaining : pickupsToCompleteObjective - m_PickupTotal;

        // update the objective text according to how many enemies remain to kill
        if (targetRemaining == 0)
        {
            CompleteObjective(GetUpdatedCounterAmount());
        }        
        else if (targetRemaining > 0)
        {
            UpdateObjective(GetUpdatedCounterAmount());
        }

    }

    public override string GetUpdatedCounterAmount()
    {
        return m_PickupTotal + " / " + pickupsToCompleteObjective;
    }
        
}

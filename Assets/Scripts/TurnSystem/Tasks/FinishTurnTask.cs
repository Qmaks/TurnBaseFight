using UnityEngine;

namespace TurnSystem.Tasks
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Turn finished!");
            Finish();
        }
    }
}
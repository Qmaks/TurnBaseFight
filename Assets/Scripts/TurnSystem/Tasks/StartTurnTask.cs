using UnityEngine;

namespace TurnSystem.Tasks
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Turn started!");
            Finish();
        }
    }
}
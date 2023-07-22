using System;
using System.Collections.Generic;

namespace TurnSystem
{
    public sealed class TurnPipeline
    {
        public event Action Finished;
        
        private readonly List<Task> _tasks = new();

        private int _currentIndex = -1;

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                Finished?.Invoke();
                return;
            }

            var currentTask = _tasks[_currentIndex];
            currentTask.Run(OnTaskFinished);
        }

        private void OnTaskFinished(Task _)
        {
            ++_currentIndex;
            RunNextTask();
        }
    }
}
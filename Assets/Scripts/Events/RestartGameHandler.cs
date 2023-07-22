using Events.Base;
using UnityEngine.SceneManagement;

namespace Events
{
    public class RestartGameEvent
    {
        
    }

    public class RestartGameHandler : BaseHandler<RestartGameEvent>
    {
        public RestartGameHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(RestartGameEvent evt)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
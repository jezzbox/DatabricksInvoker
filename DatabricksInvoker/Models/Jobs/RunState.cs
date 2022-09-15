using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{
    public class RunState
    {
        public RunState()
        {
            LifeCycleState = "PENDING";
        }
        public RunState(string lifeCycleState)
        {
            LifeCycleState = lifeCycleState;
        }

        [JsonConstructor]
        public RunState(string lifeCycleState, string? resultState, bool userCancelledOrTimedout, string? stateMessage) : this(lifeCycleState)
        {
            ResultState = resultState;
            UserCancelledOrTimedout = userCancelledOrTimedout;
            StateMessage = stateMessage;
        }

        [JsonProperty("life_cycle_state")]
        public string LifeCycleState { get; set; }

        [JsonProperty("result_state")]
        public string? ResultState { get; set; }

        [JsonProperty("user_cancelled_or_timedout")]
        public bool UserCancelledOrTimedout { get; set; }

        [JsonProperty("state_message")]
        public string? StateMessage { get; set; }
    }
}
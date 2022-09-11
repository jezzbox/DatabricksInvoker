using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs.Runs;

public class RunState
{
    [JsonPropertyName("life_cycle_state")]
    public string LifeCycleState {get; set;}
    
    [JsonPropertyName("result_state")]
    public string ResultState {get; set;}
    
    [JsonPropertyName("user_cancelled_or_timedout")]
    public bool UserCancelledOrTimedout {get; set;}
    
    [JsonPropertyName("state_message")]
    public string StateMessage {get; set;}
}
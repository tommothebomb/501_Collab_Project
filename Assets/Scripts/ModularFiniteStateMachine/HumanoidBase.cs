using UnityEngine;

public class HumanoidBase : MonoBehaviour
{
    // Libby Script \\
    public enum AnimationTriggers // can be used for both player and npcs
    {
        idle,
        walk,
        interracting
    }
    // State Machine Variables
    public HumanoidStateMachine stateMachine { get; set; }
    public RoamingState roamingState { get; set; }
    public PlayingGameState gameState { get; set; }
    public InMenuState menuState { get; set; }


    // initialize all state classes
    private void Awake()
    {
        stateMachine = new HumanoidStateMachine();
        roamingState = new RoamingState(this, stateMachine);
        gameState = new PlayingGameState(this, stateMachine);
        menuState = new InMenuState(this, stateMachine);
    }
    private void Start() => stateMachine.Initialize(roamingState);

    public virtual void AnimationTriggerEvent(AnimationTriggers trigger)
    {
        // will be useable from the animator
        stateMachine.currentState.AnimationTriggerEvent(trigger);
    }
}

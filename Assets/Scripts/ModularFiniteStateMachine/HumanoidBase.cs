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
    // Scriptable Object Variables
    [SerializeField] RoamingStateSOBase roamingBase;
    [SerializeField] GamblingStateSOBase gamblingBase;
    [SerializeField] MenuStateSOBase menuBase;

    public RoamingStateSOBase romaingBaseInstance { get; set; }
    public GamblingStateSOBase gamblingBaseInstance { get; set; }
    public MenuStateSOBase menuBaseInstance { get; set; }

    [SerializeField] NPCVoicelineStorage npcLines;
    public int npcLineType;

    // initialize all state classes
    private void Awake()
    {
        romaingBaseInstance = Instantiate(roamingBase);
        gamblingBaseInstance = Instantiate(gamblingBase);
        menuBaseInstance = Instantiate(menuBase);

        stateMachine = new HumanoidStateMachine();
        roamingState = new RoamingState(this, stateMachine);
        gameState = new PlayingGameState(this, stateMachine);
        menuState = new InMenuState(this, stateMachine);
        npcLines = new NPCVoicelineStorage();
    }
    private void Start()
    {
        romaingBaseInstance.Initialize(gameObject, this);
        gamblingBaseInstance.Initialize(gameObject, this);
        menuBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(roamingState);
        npcLines.thisNPC = (NPCVoicelineStorage.npcType)npcLineType;

    }

    private void Update()
    {
        stateMachine.currentState.FrameUpdate();
    }

    public virtual void AnimationTriggerEvent(AnimationTriggers trigger)
    {
        // will be useable from the animator
        stateMachine.currentState.AnimationTriggerEvent(trigger);
    }
    public void PlayVoice()
    {
        npcLines.PlayVoiceLine(this.gameObject);
        npcLines.playedLine = false;
    }
}

using UnityEngine;

public class TestStateMachine : MonoBehaviour
{
    public HumanoidBase player;
    public enum states
    {
        roaming, 
        inGame,
        inMenu
    }
    public states state = states.roaming;
    private states currentState = states.roaming;


    private void Update()
    {
        if (state == currentState) return;
        else
        {
            currentState = state;
            switch (state)
            {
                case states.roaming:
                    player.stateMachine.ChangeState(player.roamingState);
                    break;
                case states.inGame:
                    player.stateMachine.ChangeState(player.gameState);
                    break;
                case states.inMenu:
                    player.stateMachine.ChangeState(player.menuState);
                    break;
            }
        }

    }
}

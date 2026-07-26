using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] GameObject returnToMenu;
    Animator phoneAnimator;

    [SerializeField] GameObject appButtons;
    [SerializeField] GameObject closeAppButton;
    [SerializeField] GameObject settingsApp;
    [SerializeField] GameObject messagesApp;
    InputSystem_Actions inputActs;
    [SerializeField] PlayerState playerState;
    bool phoneUpPlayed = false, phoneDownPlayed = false, appOpen = false;



    #region // input enable and disable
    private void OnEnable()
    {
        inputActs = new InputSystem_Actions();
        inputActs.Player.Enable();

        inputActs.Player.Menu.performed += ctx => OpenPauseMenu();
    }
    private void OnDisable() => inputActs.Player.Disable();
    #endregion

    void Start()
    {
        phoneAnimator = GameObject.FindGameObjectWithTag("PhoneUI").GetComponent<Animator>();
    }

    void OpenPauseMenu()
    {
        phoneAnimator.SetBool("isPaused", true);
        playerState.stateMachine.ChangeState(playerState.menuState);
        if (!phoneUpPlayed)
        {
            AkUnitySoundEngine.PostEvent("Play_phone_up", Camera.main.gameObject);
            phoneUpPlayed=true;
            phoneDownPlayed = false;
        }
    }

    public void ReturnToMenu()
    {
        returnToMenu.SetActive(true);
    }

    public void YesMenu()
    {
        inputActs.Player.Disable();
        SceneManager.LoadScene(0);
    }

    public void NoMenu()
    {
        returnToMenu.SetActive(false);
    }

    public void UnPause()
    {
        phoneAnimator.SetBool("isPaused", false);
        playerState.stateMachine.ChangeState(playerState.roamingState);
        CloseApp();
        if (!phoneDownPlayed)
        {
            AkUnitySoundEngine.PostEvent("Play_phone_down", Camera.main.gameObject);
            phoneDownPlayed = true;
            phoneUpPlayed = false;
        }
    }

    public void OpenSettings()
    {
        OpenApp();
        settingsApp.SetActive(true);
    }

    public void OpenMessages()
    {
        OpenApp();
        messagesApp.SetActive(true);
    }

    void OpenApp()
    {
        appButtons.SetActive(false);
        closeAppButton.SetActive(true);
        if (!appOpen)
        {
            AkUnitySoundEngine.PostEvent("Play_Phone_App_open", Camera.main.gameObject);
            appOpen = true;
            
        }
    }

    public void CloseApp()
    {
        appButtons.SetActive(true);
        closeAppButton.SetActive(false);
        messagesApp.SetActive(false);
        settingsApp.SetActive(false);
        appOpen = false;
    }
}

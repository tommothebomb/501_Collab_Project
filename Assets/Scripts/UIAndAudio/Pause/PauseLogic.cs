using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseLogic : MonoBehaviour
{
    [Header ("// REFERENCES //")]
    [SerializeField] GameObject returnToMenu;
    Animator phoneAnimator;
    [SerializeField] Image bgImg;
    InputSystem_Actions inputActs;
    [SerializeField] PlayerState playerState;
    bool phoneUpPlayed = false, phoneDownPlayed = false, appOpen = false;

    [Header ("// APPS //")]
    [SerializeField] GameObject appButtons;
    [SerializeField] GameObject closeAppButton;
    [SerializeField] GameObject settingsApp;
    [SerializeField] GameObject messagesApp;
    [SerializeField] GameObject clockApp;
    [SerializeField] GameObject readingApp;
    [SerializeField] GameObject cornApp;



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
        bgImg.color = new Color(0.75f, 0.75f, 0.75f, 1f);
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
        bgImg.color = new Color(0f, 0.5f, 0.8f);
    }

    public void OpenMessages()
    {
        OpenApp();
        messagesApp.SetActive(true);
        bgImg.color = new Color(0.27f, 0.7f, 0.3f);
    }

    public void OpenClock()
    {
        OpenApp();
        clockApp.SetActive(true);
        bgImg.color = new Color(0.25f, 0.25f, 0.25f);
    }

    public void OpenReading()
    {
        OpenApp();
        readingApp.SetActive(true);
        bgImg.color = new Color(0.9f, 0.5f, 0.3f);
    }

    public void OpenCornPub()
    {
        OpenApp();
        cornApp.SetActive(true);
        bgImg.color = new Color(0f, 0f, 0f);
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
        clockApp.SetActive(false);
        readingApp.SetActive(false);
        cornApp.SetActive(false);
        appOpen = false;
        bgImg.color = new Color(0.75f, 0.75f, 0.75f);
    }
}

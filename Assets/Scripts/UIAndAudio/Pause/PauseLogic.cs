using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] GameObject returnToMenu;
    Animator phoneAnimator;

    void Start()
    {
        phoneAnimator = GameObject.FindGameObjectWithTag("PhoneUI").GetComponent<Animator>();
    }

    public void ReturnToMenu()
    {
        returnToMenu.SetActive(true);
    }

    public void YesMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NoMenu()
    {
        returnToMenu.SetActive(false);
    }

    public void UnPause()
    {
        phoneAnimator.SetBool("isPaused", false);
    }
}

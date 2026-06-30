using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    public void StartGame()
    {
        //SceneManager.LoadScene("");
    }

    public void Controls()
    {
        animator.SetTrigger("controls");
    }

    public void Credits()
    {
        animator.SetTrigger("credits");
    }

    public void Return()
    {
        animator.SetTrigger("return");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

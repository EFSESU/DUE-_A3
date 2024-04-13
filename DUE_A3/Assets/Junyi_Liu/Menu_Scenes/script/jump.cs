using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour
{
    public void waeq()
    {
        SceneManager.LoadScene("1_Junyi_Liu");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void help()
    {
        SceneManager.LoadScene("help_sence");
    }
}
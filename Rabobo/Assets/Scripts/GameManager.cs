using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool charFell = false;

    public void EndGame()
    {
        if(charFell == false)
        {
            charFell = true;
            Invoke("Restart", 2f);
        }
    }

    //Restart lvl on failure

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneScript : MonoBehaviour
{
    public string sceneName;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

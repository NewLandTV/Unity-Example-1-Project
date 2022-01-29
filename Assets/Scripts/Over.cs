using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        Debug.Log("게임 종료");
#else
        Application.Quit();
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public static class SceneManagerScript 
{



    public static IEnumerator ChangeScene(int i)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(i);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
    public static IEnumerator ChangeScene(string i)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(i);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}

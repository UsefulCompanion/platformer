using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    static void StartScreen()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        //EditorSceneManager.OpenScene()
    }
}

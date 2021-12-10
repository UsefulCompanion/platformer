using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuItem : MonoBehaviour
{
    [UnityEditor.MenuItem("OpenScene/StartScreen %u")]
    static void StartScreen()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/StartScreen.unity");
    }
}

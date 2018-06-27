using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static void LoadSelectedLevel (int selectedLevel) {
        SceneManager.LoadScene(selectedLevel);
    }

}

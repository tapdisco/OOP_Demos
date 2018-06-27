using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Button : MonoBehaviour {

    void OpenLevel1 () {
        StartCoroutine("LoadLevelAfterTransition");
    }

    IEnumerator LoadLevelAfterTransition() {
        yield return new WaitForSeconds(2.5f);
        LevelLoader.LoadSelectedLevel(1);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    // Start in landscape mode
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void StartGame() {
        SceneManager.LoadScene("Level01");
    }
}

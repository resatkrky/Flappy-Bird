﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    public void PlayButton () {
        SceneManager.LoadScene ("PlayScene");
    }

    // Update is called once per frame
    void Update () {

    }
}
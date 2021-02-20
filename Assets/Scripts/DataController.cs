using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
    public static DataController ornek;

    private const string High_Score = "High Score";

    // Start is called before the first frame update
    void Awake () {
        TekilNesne ();
    }

    void TekilNesne () {
        if (ornek != null) {
            Destroy (gameObject);
        } else {
            ornek = this;
            DontDestroyOnLoad (gameObject);
        }
    }

    void Oyunilkdefabasladi () {
        if (PlayerPrefs.HasKey ("Oyunilkdefabasladi")) {
            PlayerPrefs.SetInt (High_Score, 0);
            PlayerPrefs.SetInt ("Oyunilkdefabasladi", 0);
        }
    }

    public void setHighScore (int score) {
        PlayerPrefs.SetInt (High_Score, score);
    }

    public int getHighScore () {
        return PlayerPrefs.GetInt (High_Score);
    }

    // Update is called once per frame
    void Update () {

    }
}
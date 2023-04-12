using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT; //shared through all instances of high score
    static private int _SCORE = 1000; //if something is wrong then it is only in this class

    private Text txtCom;

    void Awake(){ //awake is before start
        _UI_TEXT = GetComponent<Text>();
        //if high score already exists then use that one
        if(PlayerPrefs.HasKey("HighScore")){
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        //assign a high score
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE{ //anything script can call score by typing high score.Score
        get {return _SCORE;}
        private set { //anything can get but only high score can set
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if(_UI_TEXT != null){
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }
    static public void TRY_SET_HIGH_SCORE (int scoreToTry){
        if(scoreToTry<= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void onDrawGizmos(){
        if(resetHighScoreNow){
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000");
        }
    }

}

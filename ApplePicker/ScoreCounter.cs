using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This line enables use of uGUI classes so we can access text

public class ScoreCounter : MonoBehaviour
{
    [Header ("Dynamic")] //means it updates during the game
    public int score = 0;
    
    private Text uiText; // stores a reference
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>(); //slow
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0"); //Somehow this means 0
    }
}

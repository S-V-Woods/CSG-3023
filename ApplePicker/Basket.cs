using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        //find score counter in hierachy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //get scoreCounter script get scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move x position of mouse to the basket
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
        
    }

    void OnCollisionEnter (Collision coll){
        //Find what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")){
            Destroy(collidedWith);
            //change the score for every apple
            scoreCounter.score += 100; //changes score by going into the score counter script
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}

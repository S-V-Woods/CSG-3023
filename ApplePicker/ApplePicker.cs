using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList; //simply null
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>(); //given a value
        for (int i=0; i< numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject> (basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y =basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        
    }
    public void AppleMissed(){
        //destroy missed apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in appleArray){
            Destroy(tempGO);
        }
        //get index of last basket to destroy
        int basketIndex = basketList.Count -1;
        //get a reference
        GameObject basketGO = basketList[basketIndex];
        //remove basket from index
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        // if no more baskets then restart
        if(basketList.Count == 0){
            SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

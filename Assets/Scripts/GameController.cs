
using UnityEngine;
using System;

public class GameController  : MonoBehaviour
{
    [SerializeField] GameObject FillPrefab;
    [SerializeField] Transform[] allCells;

    public static Action<string> slide;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SpawnFill();
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            slide("W");
        } else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            slide("S");
        } else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            slide("A");
        } else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            slide("D");
        }
    }


    public void SpawnFill() {
        int whichSpawn = UnityEngine.Random.Range(0,allCells.Length);
        
        if(allCells[whichSpawn].childCount != 0) {
             SpawnFill();
             return; 
        }
        float chance = UnityEngine.Random.Range(0.0f, 1.0f);
    
        if(chance < .2f) {
            return;
        } else if(chance < .8f) {
            GameObject tempFill = Instantiate(FillPrefab, allCells[whichSpawn]);
            FillGame temp = tempFill.GetComponent<FillGame>();
            allCells[whichSpawn].GetComponent<Cell>().fill = temp;
            temp.FillValueUpdate(2);

        } else {
            GameObject tempFill = Instantiate(FillPrefab, allCells[whichSpawn]);
            FillGame temp = tempFill.GetComponent<FillGame>();
            allCells[whichSpawn].GetComponent<Cell>().fill = temp;
            temp.FillValueUpdate(4);
        }
    }
 
}

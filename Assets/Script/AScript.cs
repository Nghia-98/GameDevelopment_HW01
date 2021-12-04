using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AScript : MonoBehaviour {
    [SerializeField] float moveSpeed = 8f;

    void Awake() {

    }

    // Start is called before the first frame update
    void Start() {
        #region Random position for Game_Object_A at (0, X, 0), with X in [10, 20]

        transform.position = new Vector3(0, Random.Range(10, 20), 0);

        Debug.Log("GameObject_A position: " + transform.position);
        #endregion



    }

    // Update is called once per frame
    void Update() {
        #region Listen event KeyDown (A,W,S,D, or Arrow_Key) to move GameObject_A

        // Move to left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime; 
        }

        // Move to right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }

        // Move up
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        }

        // Move down
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        }

        #endregion
    }
}

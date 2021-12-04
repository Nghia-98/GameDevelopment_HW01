using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AScript : MonoBehaviour {
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] int rotationSpeed = 90;

    // The first gameObjectB from Unity UI
    [SerializeField] GameObject gameObjectB;

    bool isRotateA = false;
    bool isRotateB = false;

    private bool isUp = false;

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

        #region Listen event KeyDown (Space) to Spawn GameObject_B and that has AddForce + Gravity

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("You are press key Space");
            // Random positon
            Vector3 randomPos = new Vector3(Random.Range(-4, 3), Random.Range(10, 10 + 1612426 % 10), Random.Range(-14, -5));

            // create new GameObject_B
            GameObject newGameObject_B = Instantiate(gameObjectB, randomPos, Quaternion.identity);

            // Add Gravity and AddForce
            Rigidbody newRb = newGameObject_B.GetComponent<Rigidbody>();
            newRb.useGravity = true;
            newRb.AddForce(Vector3.forward * 200);
        }
        #endregion

        #region Listen event KeyDown (Q) to destroy GameObject_B after 2s

        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("You are press key Q");

            GameObject[] gameObjectsB;
            gameObjectsB = GameObject.FindGameObjectsWithTag("GameObjectB");

            if (gameObjectsB.Length == 0) {
                Debug.Log("No game objects are tagged with 'GameObjectB'");
            }
            else {
                for (int i = 0; i < gameObjectsB.Length; i++) {
                    Destroy(gameObjectsB[i], 2);
                }
            }
        }
        #endregion

        #region Listen event KeyDown (R) to Rotation GameObject_A

        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("You are press key R");

            isRotateA = !isRotateA;
        }

        if (isRotateA) {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else {
            transform.Rotate(0, 0, 0);
        }
        #endregion

        #region Listen event KeyDown (T) to Rotation GameObject_B

        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("You are press key T");

            isRotateB = !isRotateB;
        }

        if (isRotateB) {
            GameObject[] gameObjectsB;
            gameObjectsB = GameObject.FindGameObjectsWithTag("GameObjectB");

            if (gameObjectsB.Length == 0) {
                Debug.Log("There are no GameObjetB");
                isRotateB = false;
                isUp = false;
            }
            else {
                for (int i = 0; i < gameObjectsB.Length; i++) {
                    gameObjectsB[i].GetComponent<Rigidbody>().useGravity = false;
                    gameObjectsB[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                    gameObjectsB[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                    if (!isUp) {
                        Vector3 curPos = gameObjectsB[i].transform.position;
                        gameObjectsB[i].transform.position = new Vector3(curPos.x, curPos.y + 2, curPos.z);
                    }

                    gameObjectsB[i].transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
                }
                isUp = true;
            }
        }
        else {
            GameObject[] gameObjectsB;
            gameObjectsB = GameObject.FindGameObjectsWithTag("GameObjectB");

            if (gameObjectsB.Length > 0) {
                for (int i = 0; i < gameObjectsB.Length; i++) {
                    gameObjectsB[i].transform.Rotate(0, 0, 0);
                    gameObjectsB[i].GetComponent<Rigidbody>().useGravity = true;
                }
            }
            isUp = false;
        }
        #endregion
    }
}


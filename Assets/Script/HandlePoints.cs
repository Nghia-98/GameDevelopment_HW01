using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePoints : MonoBehaviour {
    public static int point = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public int getPoint() {
        return point;
    }

    public void IncreasePoint() {
        point +=1;
    }
}

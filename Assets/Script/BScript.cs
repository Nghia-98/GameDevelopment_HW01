using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BScript : MonoBehaviour
{
    HandlePoints pointDealer;

    // Start is called before the first frame update
    void Start()
    {
        pointDealer = GetComponent<HandlePoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        pointDealer.IncreasePoint();
        Debug.Log("Point: " + pointDealer.getPoint());
        Destroy(gameObject);
    }
}

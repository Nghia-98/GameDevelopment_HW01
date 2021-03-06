using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onChangeColorB : MonoBehaviour
{
    //This stores the GameObjectís original color
    Color m_OriginalColor = Color.white;

    //Get the GameObjectís mesh renderer to access the GameObjectís material and color
    MeshRenderer m_Renderer;

    void Start() {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }

     void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("You are press key C");

            m_Renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}

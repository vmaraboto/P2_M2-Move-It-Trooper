using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Speed of Movement
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {
        // Calls movement function
        MovePlanet();

        // Exits game when esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    // Movement function
    void MovePlanet()
    {
        // X and Y variables
        float moveX = 0f;
        float moveY = 0f;

        // Key detection
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        // Movement application
        Vector2 movePosition = new Vector2(moveX, moveY).normalized;
        transform.position += (Vector3)movePosition * speed * Time.deltaTime;
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}

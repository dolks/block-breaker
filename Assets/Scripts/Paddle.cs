using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * 23f;
        transform.position = new Vector2(Mathf.Clamp(mousePos, 3f, 20f), transform.position.y);
    }
}

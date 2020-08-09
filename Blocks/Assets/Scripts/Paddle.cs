using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float screenWidthInUnits = 21.3f;
    float minX = 1;
    float maxX = 20;

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, minX, maxX);
        transform.position = paddlePosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 2f;
    [SerializeField] float maxX = 20f;
    [SerializeField] float widthScreenWidthInUnits = 21.3f;

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits =  Input.mousePosition.x / Screen.width * widthScreenWidthInUnits;
        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, minX, maxX);
        transform.position = paddlePosition;
    }
}

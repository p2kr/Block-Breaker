using UnityEngine;

public class Paddle : MonoBehaviour
{
    //  Configuration parameters
    [SerializeField] private float minX = 1;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        mousePosInUnits = Mathf.Clamp(mousePosInUnits, minX, maxX);
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        transform.position = paddlePos;
    }
}
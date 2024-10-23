using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private LevelGrid levelGrid;
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;//we want the grid position to change automatically evert certain amount of time so to do that create a variable to count the time. this will contain the time remaining until the next movement 
    private float gridMoveTimerMax; // define a variable to whom the time between moves. this will be contain the amount of time between moves
    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = 0.5f; // snake move on all grid ever half second  
        gridMoveTimer = gridMoveTimerMax; // every second snake will move on the grid 
        gridMoveDirection = new Vector2Int(1, 0);
    }
    public void SetUp(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;

    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleGridMovement();
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != +1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != +1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            gridMoveDirection.x = 0;
            gridMoveDirection.y = 0;
        }
    }
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            if (gridMoveDirection != Vector2Int.zero)
            {
                transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection));
            }
            levelGrid.SnakeMoved(gridPosition);
        }
    }
    private float GetAngleFromVector(Vector2Int direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0) { angle += 360; }
        return angle - 90;
    }
    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
}


using UnityEngine;

public class LevelGrid
{
    private SnakeController snakeController;
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int width;
    private int height;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        SpawnFood();
    }
    public void SetUp(SnakeController snakeController)
    {
        this.snakeController = snakeController;
    }
    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        } while (snakeController.GetGridPosition() == foodGridPosition);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public void SnakeMoved(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Debug.Log("SNAKE ATE FOOD");
        }
    }
}

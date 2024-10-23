using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private LevelGrid levelGrid;
    [SerializeField] private SnakeController snakeController;

    private void Start()
    {
        /*GameObject snakeHeadGameObject = new GameObject();
        SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        snakeSpriteRenderer.sprite = GameAssets.instance.snakeHeadSprite;*/
        levelGrid = new LevelGrid(19, 19);
        snakeController.SetUp(levelGrid);
        levelGrid.SetUp(snakeController);
    }
}

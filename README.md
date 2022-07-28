# Snake Game

A project to visualize what the movement is like in the snake game using lists to reposition the body.

## Movement
With each step that the snake's head takes, the last position is stored, where the last tile of its body will be placed.

The movement is performed every 0.3 seconds at the beginning, and every 1/4 minute the time to take a step is reduced by .01 seconds.

```
xooooO -> xoooo O -> ooooxO
```
```csharp
 IEnumerator Move(float secondsToMove)
    {
        lastPosition = transform.position;
        transform.Translate(dir);
        InsertTailTile(lastPosition);
        yield return new WaitForSeconds(secondsToMove);
        if (secondsToMove >.08f)
        {
            if (timePassed >= 15)
            {
                timePassed = 0;
                secondsToMove -= .01f;
            }
        }
        StartCoroutine(Move(secondsToMove));
    }
```

## Body tiles

If the food is collected, a tile is directly inserted into the space between the head and the body, otherwise the last piece of the body is repositioned.
```csharp
void InsertTailTile(Vector2 position)
{    
        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailTilePrefab, position, Quaternion.identity);
            tailTilesList.Insert(0, g.transform);
            ate = false;
            
        }
        else if(tailTilesList.Count > 0)
        {
            tailTilesList.Last().position = position;
            tailTilesList.Insert(0, tailTilesList.Last());
            tailTilesList.RemoveAt(tailTilesList.Count - 1);
        }
}
```
## Play the game
https://lketerson.itch.io/snake-game

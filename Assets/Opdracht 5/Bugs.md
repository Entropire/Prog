# Opdracht 5: Debugin

## Bugs

1. [Tower misplacement](#bug-1-tower-misplacement)
2. [Button overlap click trigger](#bug-2-button-overlap-click-trigger)
3. [null](#bug-3) - **Inprogress**

---
   
## Bug 1: Tower Misplacement.

![Gif](https://github.com/Entropire/Prog/blob/main/Assets/Opdracht%205/Bug1.gif)

### Description

When placing a tower on the grid, the tower sometimes gets placed in the wrong cell. Specifically:

- If the mouse is in the bottom-left or bottom-right corner of a cell, the tower is placed in the cell below.
- If the mouse is in the top-left corner, the tower is placed in the cell to the left.
- If the mouse is in the top-right corner, the tower is placed in the correct cell.

### Cause

This bug comes from the code where the closest cell to the clicked position is calculated.

```csharp
private Cell GetClosestCell(Vector2 position)
{
    Cell closestCell = null;
    float closestDistance = float.MaxValue;

    for (int y = 0; y < gridSize.y; y++)
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            float distance = Vector2.Distance(grid[y][x].position, position);
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCell = grid[y][x];
            }

            if (closestDistance <= cellSpacing)
            {
                return closestCell;
            }
        }
    } 
        return closestCell;
}
```

This piece of code calculates the closest cell to the clicked position bij going through the 2d array of cell and
checking witch is the closest to the clicked position.
But for optimization it also checks if the current closestDistance is smaller than the spacing between the cells.
Because of this peace of code it sometimes places the tower on the wrong cell.

### Explanation

The code that calculates the closest cell to the clicked position start at the cell in the left bottom of the screen and
goes from left to right bottom to top.
When a mouse clicks on the screen there is most of the time more than one cell where the distance between it and the
clicked position is smaller than the cell spacing.
Because of the way that to script goes through the 2d cell array there are 3 option when a user clicks on the screen to
place a tower.

- If the mouse is in the top right part of the cell the tower gets placed in the clicked cell.
- If the mouse is in the top left part of the cell the tower gets placed in the cell to the left of the clicked cell.
- If the mouse is in the bottom left or bottom right part of the cell the tower gets placed in the cell below the
  clicked
  cell.

### Solution

There are 2 solutions to this problem.

1. Remove the part of code that checks if the closest distance is smaller than the cell spacing
   and just let the for loop run through every cell.
   This is a little less efficient because if the clicked cell is at the beginning of where the code checks it will
   still check all the other cell after that cell.


2. Divide the cell spacing by two.
   When dividing the cell spacing by two and using that instead of the cell spacing there will never be a closer cell
   than the cell where the user clicks in.

---

## Bug 2: Button overlap click trigger.

![Gif](https://github.com/Entropire/Prog/blob/main/Assets/Opdracht%205/Bug2.gif)

### Description

When pressing a button to go to a menu and holding down the mouse button it also presses the button in the new menu if
the two button overlap.

### Cause

This issue occurs because the code checks in every frame whether the mouse button is pressed and, if so, whether the
mouse is inside the button area.

```csharp
internal override void Update(GameTime gameTime)
{
    Vector2 mousePosition = Mouse.GetState().Position.ToVector2();

    if (mousePosition.X > position.X &&
        mousePosition.X < position.X + size.X &&
        mousePosition.Y > position.Y &&
        mousePosition.Y < position.Y + size.Y)
    {
        textureToUse = buttonHoverTexture;
        if (InputHandler.IsLeftMouseButtonPressed())
        {
            onClick?.Invoke(this);
        }
    }
    else
    {
        textureToUse = buttonTexture;
    }
} 
```

### Explanation

Since each button checks every frame if the mouse button is pressed, when the user clicks and holds the left mouse
button, the program switches scenes and may also trigger a button in the next scene if it is located in the same general
area.

### Solution

Modify the part of the code that checks if the mouse is down and replace it with a check that detects if the mouse is
clicked. This can be achieved by setting a boolean flag to true when the left mouse button is pressed and resetting it
to false either when the mouse button is released or after one frame has elapsed.

It is also better to move the mouse button check out of the button's update function and place it in an input manager.
In the input manager, create an update loop that checks if the left mouse button is pressed. When it is, trigger an
event that calls the OnClick function that checks if the mouse is inside the button area for all subscribed buttons.

---

## Bug 3:

![Gif](https://github.com/Entropire/Prog/blob/main/Assets/Opdracht%205/Bug3.gif)

### Description

### Cause

### Explanation

### Solution

<h1>Top Down Game</h1>

PlayerController: 
- OverlapBox Movement Based
- InputHandler.cs -> InputRSE -> PlayerController.cs
- Movement Points number of movement you can do in a level if its equal to 0 you lose and go to the main menu
- Vision fog of war: FogVision destroy the celling tiles to see the map

Items:
- Item Class with OnTriggerEnter Player Detection
- Add Item to RSO_Items and destroy itself

Exit:
- RSE_OpenScene is call to change level when the Exit is trigger
- OnTriggerEnter detect if player tag and RSO_Items > requiredItemQuantity

Fog of war:
- Celling tiles place on the top of the map
- Can be destroy only by the FogVision

Ghost:
- Have a timer and can pass trough the wall
- When pick up start the timer and disable the wall collider
- RSE_StartGhostItemTimer
- Destroy himself when pick up

Wall:
- Have a scripts to disable the collider
- If the player is in the wall restart the level

Scenes :
- 3 Levels
- Main Menu
- SceneManager.cs -> RSE_OpenScene -> Change scene
Launch the game on the MainMenu scene to play

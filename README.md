<h1>Top Down Game</h1>

PlayerController: 
- OverlapBox Movement Based
- InputHandler.cs -> InputRSE -> PlayerController.cs

Items:
- Item Class with OnTriggerEnter Player Detection
- Add Item to RSO_Items and destroy itself

Exit:
- RSE_ExitReached call on Exit reach
- OnTriggerEnter detect if player tag and RSO_Items > requiredItemQuantity
- Do Something (actually destroy player)

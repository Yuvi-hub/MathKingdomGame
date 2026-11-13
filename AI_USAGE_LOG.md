# AI usage log — Math Kingdom

AI assisted with the initial class design, C# source files, scene bootstrap.


## Architecture review
- Gameplay classes communicate score and finish changes through `GameSignals` events.
- `GameHUD` subscribes in `OnEnable` and unsubscribes in `OnDisable`.
- Runtime bootstrap creates a sample level and configures components; this is a deliberate deviation from prefab-authored scenes to make the source package portable.
- `GameSignals` is static as a small, project-wide event channel; no persistent singleton is used.



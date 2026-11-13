# AI usage log — Math Kingdom

AI assisted with the initial class design, C# source files, scene bootstrap and README.
The project was generated outside Unity and has **not** been editor-tested or built to WebGL.

## Architecture review
- Gameplay classes communicate score and finish changes through `GameSignals` events.
- `GameHUD` subscribes in `OnEnable` and unsubscribes in `OnDisable`.
- Runtime bootstrap creates a sample level and configures components; this is a deliberate deviation from prefab-authored scenes to make the source package portable.
- `GameSignals` is static as a small, project-wide event channel; no persistent singleton is used.

## Required human verification
Open in Unity, generate the scene, test gameplay, inspect Console, and update this log with actual test outcomes and any code/diagram deviations.

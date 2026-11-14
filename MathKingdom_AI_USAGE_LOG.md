# AI Usage Log — Math Kingdom

## Assignment 4: Core Gameplay, Physics and Architecture



### . Architecture Review

AI was used to review the planned architecture and compare it with the implementation.

The game is organized into components with separate responsibilities:

| Component | Responsibility |
|---|---|
| GameBootstrap | Creates the level and game objects |
| PlatformPlayer | Handles movement, jumping, and collisions |
| NumberPickup | Handles collecting numbered objects |
| GoalPortal | Detects when the player reaches the goal |
| MathGameState | Manages the score, timer, and win/lose conditions |
| GameSignals | Publishes gameplay events |
| GameHUD | Displays the score, timer, and game result |

This separation follows the Single Responsibility Principle.

### 3. Differences Between Planned and Final Architecture

**Change 1 — Separation of gameplay and UI**

The game logic and user interface were organized into separate components.

The final architecture uses `GameSignals` to notify the HUD about score changes and game results.

**Reason:** Reduce dependencies between gameplay logic and UI code.

**Change 2 — Separation of player movement and game rules**

Player movement and jumping are handled by `PlatformPlayer`, while scoring, timing, and win/lose conditions are handled by `MathGameState`.

**Reason:** Make gameplay rules easier to modify without affecting movement physics.

**Change 3 — Centralized game-state management**

Score, remaining time, and game completion are managed through `MathGameState` rather than being distributed across collectibles and other game objects.

**Reason:** Keep the game rules consistent and make future extensions easier.

These points describe the final architectural organization. They should be treated as differences from the original design only where the original design actually used another approach.

### . Physics Implementation Review

Math Kingdom uses Unity's 2D physics system.

| Physics feature | Implementation |
|---|---|
| Rigidbody2D | PlatformPlayer |
| AddForce | PlatformPlayer jumping |
| Collision2D | Ground and hazard collision detection |

The other two physics requirements, `CharacterController` and `Raycast`, are covered by Code Escape.

Together, the two projects are designed to demonstrate all five physics features required by Assignment 4.

### . Event-Based Communication

The game uses `GameSignals` to communicate gameplay changes.

- `MathGameState` publishes score updates.
- `GameSignals.ScoreChanged` notifies `GameHUD`.
- `MathGameState` publishes game completion events.
- `GameSignals.GameFinished` notifies `GameHUD`.

This design avoids direct communication between the game-state logic and UI implementation.

### . Architecture Decisions

**Decision 1 — Event-based communication**

Chosen approach: C# events.

Alternative: direct method calls to the HUD.

Reason: events make the UI easier to replace or extend without changing the game rules.

**Decision 2 — Separate gameplay components**

Chosen approach: specialized scripts for movement, collectibles, scoring, and UI.

Alternative: a single script controlling the entire game.

Reason: smaller components are easier to maintain and debug.

**Decision 3 — Unity physics for movement**

Chosen approach: Rigidbody2D and AddForce.

Alternative: manually changing the player's position for jumping.

Reason: Unity physics provides gravity and collision handling.

### . Testing and Debugging

Development and testing focused on:
- Player movement and jumping.
- Collecting numbered objects.
- Updating the displayed score.
- Detecting the goal portal.
- Handling win and lose conditions.
- Restarting the game.

AI assistance was used to review the code structure and suggest improvements to component responsibilities and event communication.

### . AI Contributions and Developer Decisions

AI assisted with writing code, organizing the project, preparing architecture diagrams, and documenting the implementation.

The developer was responsible for opening the project in Unity, testing gameplay, identifying issues, and deciding which revisions to use.

The final architecture emphasizes separation of responsibilities, configurable gameplay values, and event-based UI updates.

### . Conclusion

AI assistance supported the development and architectural review of Math Kingdom.

The review focused on separating player movement, mathematical game rules, collectibles, and UI communication.

Math Kingdom demonstrates 2D physics and event-based architecture, while Code Escape complements it with additional Unity physics features.

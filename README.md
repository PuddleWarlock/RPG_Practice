# Action RPG

**Action RPG** is a 3rd-person combat-focused game developed as a coursework project. The main goal was to implement a clean animation-driven combat system, complex character states, and AI pathfinding.

## 🛠 Technical Stack
* **Engine:** Unity (C#)
* **Key Features:** State Machines, Unity NavMesh, Custom IK, Animation Events.

## ⚙️ Core Systems & Code Architecture

* **Hierarchical State Machines:** 
  * Implemented a custom FSM that separates **Movement** (Idle, Walk, Sprint, Jump, Fall) from **Combat** (Sheathed, IdleAttack, Melee, SpellCast).
  * Allows smooth blending between actions without animation locks.
* **Animation-Driven Logic:** 
  * Combat mechanics heavily rely on `Animation Events` to enable/disable weapon hitboxes at exact frames, preventing phantom hits.
  * Uses `Custom IK (Inverse Kinematics)` via `StateMachineBehaviour` to procedurally rotate the player's spine and aiming hand towards the camera's look direction, making ranged combat feel responsive.
* **Modular Skill System:** 
  * Abilities (Fireball, Meteor Rain, Heavy Attack) are encapsulated into separate classes implementing the `ISkill` interface.
  * Instantiated dynamically via `Activator` based on `ScriptableObject` configurations.
* **Enemy AI & Aggro System:**
  * Driven by NavMesh for pathfinding.
  * AI behavior reacts to HP levels (e.g., entering a `FearState` to run away when HP is below 30%) and distances.
* **Robust UI Management:** A custom `ViewManager` handles UI screen switching and prevents overlapping menus.

## 🎮 Gameplay Mechanics
* **Weapon Drawing System:** Unsheathing/Sheathing weapons dynamically changes the character's movement and attack capabilities.
* **Melee & Ranged Combat:** Responsive sword combat and projectile-based magic casting.
* **Enemy Spawner & Waves:** Procedural enemy spawning within defined areas and a boss spawn trigger when waves are cleared.

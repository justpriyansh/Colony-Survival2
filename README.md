# Colony Survival Prototype

A Unity prototype that simulates a colony's food and water reserves over time. The project demonstrates clean architecture by separating simulation logic from Unity-specific code while loading all gameplay values from JSON configuration files.

## Unity Version

Unity 6000.3.6f1 , SampleScene

---

## Features

- Loads colony data from JSON files
- Loads consumption rates from JSON files
- Simulates one game day every one real second
- Decreases food and water based on population and consumption rate
- Displays:
  - Current Day
  - Population
  - Food Remaining
  - Water Remaining
  - Food Days Remaining
  - Water Days Remaining
- Displays a "Colony Starving" state when food or water reaches zero
- Pure C# simulation logic
- EditMode unit tests using Unity Test Framework

---

## Architecture

The project follows a separation between Unity-specific code and game logic.

### MonoBehaviour Classes

- GameManager
- UIManager

Responsibilities:
- Load JSON data
- Initialize the simulation
- Update the UI
- Control the game loop

### Pure C# Classes

- Simulation
- ColonyState
- PopulationConfig
- ConsumptionConfig

Responsibilities:
- Resource consumption
- Day progression
- Remaining days calculation
- Starvation detection

These classes do not inherit from `MonoBehaviour` and do not reference `UnityEngine`.

---

## JSON Configuration

### population.json

```json
{
    "villagers": 10,
    "startingFood": 100,
    "startingWater": 100
}
```

### consumption.json

```json
{
    "foodPerVillagerPerDay": 1,
    "waterPerVillagerPerDay": 2
}
```

---

## How to Run

1. Open the project in Unity 6000.3.6f1.
2. Open the SampleScene scene.
3. Press Play.
4. The simulation automatically starts.
5. Every second represents one game day.

---

## Running Unit Tests

1. Open:

```
Window → General → Test Runner
```

2. Select the **EditMode** tab.

3. Click **Run All**.

The tests verify:

- Day progression
- Food consumption
- Water consumption
- Food days remaining calculation
- Water days remaining calculation
- Starvation detection

---

## AI Tools Used

The following AI tools were used during the development of this project:

- **ChatGPT** – Assisted with project planning, architecture design, debugging, unit testing, and documentation.
- **Antigravity AI** – Assisted with C# code generation, code suggestions, and improving development workflow.

All AI-generated suggestions were reviewed, integrated, tested, and adapted within Unity before being included in the final project.

---

## Decisions & Trade-offs

- The simulation uses an accelerated clock where one real second equals one game day.
- The simulation logic is completely separated from Unity components to improve testability.
- The project focuses only on the required functionality and avoids additional gameplay features such as seasons, buildings, or population growth.

---

## Demo Video

https://drive.google.com/file/d/11QjsnDVUrqCKoRiZUxH6h_qtSeHn7mti/view?usp=drive_link
---

# Problem Solutions and Code Explanation

This repository contains solutions to three distinct problems, each showcasing different approaches to development challenges in Unity and C#. Below is a detailed explanation of each problem and its solution.

---

## Problem 1: Moving Objects in Unity

### Context
The solution to moving objects in Unity depends on the type of object and its intended behavior:

1. **UI Elements**:
   - Use **DOTween** for animating movements, as animations are essential in games.

2. **Projectiles or Bullets**:
   - Implement **Jobs and Burst** for optimization, as these objects may exist in large quantities. This approach leverages multi-threading to improve performance on modern devices.

3. **Game Units**:
   - Use **NavMeshAgent** or **A\* Pathfinding** for pathfinding and crowd movement. A\* provides optimized solutions for handling multiple units and simple AI.

4. **Physics-Interacting Objects**:
   - Move these objects using **RigidBody** to ensure they respect game physics. Avoid using `transform` for movement, as it bypasses physics calculations.

### Default Approach
If the object context is unknown, **DOTween** is the simplest and most flexible starting point. It can be replaced later as the requirements become clearer.

---

## Problem 2: Creating a UI with Currency Indicators

### Overview
The task was to create three buttons and currency indicators. While simple, proper organization and scalable architecture were prioritized.

### Steps Taken
1. **Setup**:
   - Integrated **FEEL** for player feedback.
   - Used **UGUI Casual Game** for UI prefabs.
   - Added **Zenject** for dependency injection and **UniTask** for asynchronous tasks.
   - Utilized **POLYGON** assets for visual effects.

2. **Architecture**:
   - Added a humanoid character with animations to visualize resource collection.
   - Used **EventBus** for centralized communication between UI and the 3D world.

3. **UI Animation**:
   - Simplified animation using a custom **UIManager** instead of **DoozyUI**.

4. **Object Spawning**:
   - Implemented a **Zenject** factory, later simplified to a generic factory for faster prototyping.

5. **Scalability**:
   - Dynamically spawned UI buttons and indicators based on **ScriptableObject** settings, allowing easy addition of new currencies.

6. **Rendering**:
   - Used **URP**, optimized for mobile devices.

### Planned Improvements
- Create a custom grass shader optimized for mobile.
- Implement a save system (e.g., **PlayerPrefs**).
- Separate dependency injection into multiple installers.
- Use additive scene loading for modular game levels.

---

## Problem 3: Single-Pass Algorithm for Maximum Profit

### Problem Statement
Given an array of prices, find the maximum profit that can be achieved by buying and selling a stock, with a time complexity of \(O(n)\).

### Solution
The algorithm uses a single pass through the array:

```csharp
public class Solution {
    public int MaxProfit(int[] prices) {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices) {
            if (price < minPrice) {
                minPrice = price;
            } else {
                maxProfit = Math.Max(maxProfit, price - minPrice);
            }
        }

        return maxProfit;
    }
}

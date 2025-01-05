# Problem Solutions and Code Explanation

Case study of Just Play solution

---

## Problem 1: Moving Objects in Unity

### Context
The solution to moving objects in Unity depends on the type of object and its intended behavior:

1. **UI Elements**:
   - Use **DOTween** for animating movements, as animations are essential in games.

2. **Projectiles or Bullets**:
   - Implement **Jobs and Burst** for optimization, as these objects may exist in large quantities. This approach leverages multi-threading to improve performance on modern devices.

3. **Game Units**:
   - Use **NavMeshAgent** or **A* Pathfinding** for pathfinding and crowd movement. A\* provides optimized solutions for handling multiple units and simple AI.

4. **Physics-Interacting Objects**:
   - Move these objects using **RigidBody** to ensure they respect game physics. Avoid using `transform` for movement, as it bypasses physics calculations.

### Default Approach
If the object context is unknown, **DOTween** is the simplest and most flexible starting point. It can be replaced later as the requirements become clearer.
You can also use the regular Vector3.MoveTowards, and to determine if the object has reached the destination, use Vector3.Distance(a, b).
---

## Problem 2: Prototype

[![SXlDK.gif]([https://s13.gifyu.com/images/SXlDK.gif)](https://gifyu.com/image/SXlDK](https://github.com/AlexanderDevelopment/CaseStudyForJustPlayDemo/blob/main/demo.gif?raw=true))

[Play prototype](https://alexanderdevelopment.github.io/CaseStudyForJustPlayDemo/)


### Overview
The task of creating just three buttons and a currency indicator seemed too simple to me, but for this project, as with any project, it was necessary to first organize the workspace.
I used the FEEL asset for convenient switching between different player feedbacks, laid out a simple UI using ready-made prefabs from the UGUI Casual Game asset, took VFX effects from POLYGON, integrated Zenject for dependency injection, and UniTask for asynchronous tasks.
Next, I began planning the project architecture. I initially wanted to visualize resource gathering somehow, so I decided to integrate a simple humanoid with animations and a pickaxe. Based on this, I needed to somehow connect the UI and the 3D world, and I thought about UniRx but decided that a regular EventBus pattern would be enough. This way, we can subscribe to and listen to different objects from each other, and everything will be centralized in one place, which makes it easy to debug and extend for future requests. I also wanted to use DoozyUI for animating UI windows and organizing them in streams, but I thought my personal UIManager would handle the tasks for this test assignment more simply, and the simpler, the better.
For object spawning and dependency injection with Zenject, I used a factory pattern from Zenject, but I decided to simplify it and wrote a factory for generic objects so as not to create a separate factory for each class we want to spawn (this is a bit more resource-intensive, but at this stage of prototyping, it's just more convenient, since we don't know the final number of objects to spawn). Additionally, I used the command pattern so that the central game state could command the 3D world about changes in the game, and they would respond accordingly. I tried to make access to all objects through interfaces. In my project, the high-level code is independent of the low-level code, which allows for the expansion of this project and, most importantly, the transfer of some features to other new projects. All possible project settings are placed in separate ScriptableObjects, where you can configure game settings and individual features, such as currency indicator settings. By the way, I wrote the code so that we could later add an unlimited number of currencies without taking much time. Since the buttons and indicators spawn based on the settings, we can later add new buttons and indicators, and they will automatically appear in the UI (though a separate setup for their 3D display is still needed).
For rendering, I used URP because it is more suitable for targeted devices, i.e., mobile devices.
Also, to demonstrate my skills, I created several visual effects from scratch, while the music and sound were sourced from FreeSounds.org with CC0 rights.
I also created a draft booster system, so just play the WebGL build for about 1-2 minutes, and you'll see a surprise.
The WebGL build lags a bit on mobile devices because WebGL doesn't fully support Jobs, which I use to move UI elements. There's no issue in the mobile build.

### *What I wanted to do but didn't have time for:*
- A custom grass shader, which would be significantly optimized for mobile devices.
- A save system (at least in PlayerPrefs).
- Split dependency injection into different installers, which will help navigate them better in the future.
- Add a main menu and additive scene loading with the game.
- Separate the game level into a Core scene, where all the logic will be stored, an environment scene, and a UI scene. This way, we will be able to load our levels faster, and such separation will allow us to create game levels without touching the logic scenes, which eliminates the possibility of breaking the logic. This separation also allows everything to be independent of each other and dynamically connected in the form of modules.
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

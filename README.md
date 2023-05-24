# One-Stick Survivor Shooter (Unity)
 
<img width="240" alt="Screenshot 2023-05-24 235150" src="https://github.com/FabPei/One-Stick-Survivor-Shooter/assets/80212635/d13ebf19-5e55-4304-b6b3-02c2bb02a519">
<img width="240" alt="Screenshot 2023-05-24 234948" src="https://github.com/FabPei/One-Stick-Survivor-Shooter/assets/80212635/c7d04f59-cecb-4fd9-bd71-acea8d8d5cb4">
(The reference resolution is 21:10)

A small side project. You have a functioning menu and a simple game. It's controllable by one joystick and nothing else. By killing enemies, you will receive exp points and with every lvl up you can unlock new guns and upgrades. 
Enemy types:
- Big Enemy (slower and bigger)
- Enemy
- Small Enemy (faster)

Only the normal one will spawn, the rest is implemented but not made into a spawning algorithm.

Short explanation regarding the upgrading algorithm:
The probability of each weapon is based on the total N of guns. E.g. if there are 5 guns, each probability to showing up in the selection menu is 20%.
If one gun is taken, the other guns retain their probability. The now 20% freed will be given to upgrades. In this scenario, the rocket launcher is chosen, thus the 4 upgrades for the rocket launcher have each a 5% chance to show up. Thus, the game favours unlocking each gun first.

**Assets:**
- The rights to all menu icons belong to Microsoft, they are taken from this collection: https://www.deviantart.com/vovan29/art/Windows-95-ALL-ICONS-805656804
- The player sprite, alien, guns etc are made by me, the ASESprite files are within the Assets folder. You can use them as you want, as long you don't claim to made by yourself. Also dont sell them

**How to use this repository:**
- Download everything and then open it with the GitHub Launcher

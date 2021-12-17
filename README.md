# Progeny of the Chicken's Zelda Remake
# Project Description
Our recreation of the beginning of the first Legend of Zelda game for CSE 3902. Written using Monogame in C#.

We did code reviews using pull requests, and used Visual Studio's built in code metrics.

Switch Rooms by Left/Right clicking

# Authors
- Nicholas Brinkel
- Lucas Butler
- Alex Dai
- Keith Kriston
- David Novikov
- Chalina Russell

# Controls
In the inventory you can use:
- WASD to scroll selection
- Enter to choose selection
- E to start the game
- P to pause
- M to mute the game
- Q to quit

In Gameplay, you can use:
- WASD to move
- E to enter the inventory
- B to use the secondary item
- N to use the primary item
- P to pause
- M to mute the game
- Q to quit
- Left/Right click to quickly swap betweeen rooms, although this feature is not intended to have everything work correctly

In the inventory you can use:
- WASD to scroll selection
- E to return to the game
- P to pause
- M to mute the game
- Q to quit

While the game is paused you can use:
- P to unpause
- M to mute the game

# Known Issues
- Doors don't render while room is switching
- Bombs do not affect adjacent rooms
- Potion does not have sound effect
- Potion is an instant heal instead of heal over time
- Clock is only 10 seconds (intentional change)
- Link can continue to take damage after death and cut off the death animation

# Not Implemented
- Switching Between Arrows
- Ladder
- Merchant does not sell anything

# Sprint 5 Bonus Round
- Shotgun Item
- Advancable Dialogue Boxes
- Randomized dungeon mode
- Super Hot mode (time only moves when you do)

# Post Sprint 5 bug fixes and features completed before final presentation (list more detailed that previously)
## Features:
- Added different dialogue screens for winning vs. dying
- Added instructions for how to interact with dialogue the first time it’s used
- Added dialogue for picking up the bow and shotgun
- Added dialogue for picking up a room key
- Made in game music not play in the game over, death, and main menu screens
- Created Manhandla and added to randomized dungeon
- Added bow, arrows and the ring to certain rooms in the randomized dungeons as room clear rewards
- Link pickup of triforce to animate triforce over his head
- Each shotgun pellet impact creates animation/effect and makes impact sound

## Bug Fixes/Improvements:
- Fixed bug where playing again after death wouldn’t work
- Fixed bug where the game would end before victory or death music finished playing
- Fixed a bug where the low health sound effect wouldn’t turn off if you regained health
- Fixed bug where dialogue from the dialogue box would stay on screen after leaving the room
- Fixed a bug where the game over screen would also have the instructions flashing
- Fixed a bug where link would spawn in the walls of the secret room
- Fixed bug where link would disappear/not be interact-able after being dragged by the wallmaster
- Fixed Aquamentus movement and projectiles
- Fixed chasing for mega darknut
- Fixed enemies trying to walk into walls
- Fixed missing object spawning in revisited rooms
- Fixed spawn explosions happening before link enters the room
- Fixed room25 crash on randomized dungeon
- Updated drop table to really include all enemies
- Improved Goriya getting out of sync when throwing boomerangs at walls point-blank
- Removed mouse controller to prevent bugs and enable normal gameplay
- Balanced shotgun strength
- Fixed volume on shotgun to be less loud
- Spike trap functions correctly
- Fixed shotgun pellet collision issues
- Fixed link pickup animation for non weapon/special items

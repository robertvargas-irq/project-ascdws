## Feast for a Crow <sub> \\\\ a survival-adventure by Insufficient RAM :: [Project Site](https://matrom01-v2.github.io/ProjectASCDWS_Site/)</sub>

Feast for Crows (working title) is a top-down 2D survival game meant to challenge the player with its rogue-like elements of fast, ever-changing and replayable gameplay. The core elements of the game will include Atari style graphics, reminiscent of games such as The Binding of Isaac or Faith. Players can and will encounter hostile situations including wildlife, sustenance, enemy NPCs, and something else. Among the wildlife, there are two mini bosses and one final boss to add to the overall difficulty and stakes. This game’s primary purpose should be to provide a challenge of wit over brawn, forcing the player to utilize resources efficiently and plan out what to keep and what to discard.

---

## PROJECT STRUCTURE AND NAVIGATION

All the scripts for the game are within "Hollow Bird/Assets/Scripts" and includes all of the functionality for our project.

Scripts that extend `MonoBehavior` are base, core scripts that are extended upon, specifically those that contain "`virtual`" methods that can be overridden.

While the source assets are not readily available from a simple `git clone` (see HOW TO PICK UP WHERE WE LEFT OFF below in order to get the entire project root), along with the scene objects, these Scripts can be placed in one's own Unity project as long as the unity GameObjects are created with the proper Collision Boxes if required by the script.

---

## HOW TO PICK UP WHERE WE LEFT OFF

### (1) Getting your workspace ready.

**! THE GIT REPOSITORY LIVES --ONE DIRECTORY ABOVE THE ACTUAL UNITY PROJECT FOLDER-- !**

You MUST clone the repository first (based on the release that was given to make sure the project files in the .ZIP line up with the given release's scripts).
- This can be done by adding a `-b` argument with a companion tag.
  * I.E. If you are working with `v1.0.2`, you would clone via either of the following commands:
    - `git clone https://github.com/robertvargas-irq/project-ascdws.git -b v1.0.2`
    - `git clone -b v1.0.2 https://github.com/robertvargas-irq/project-ascdws.git`

Following that, you should see 3 files and 1 directory appear.
- {dir/} "Hollow Bird"  <---- this folder will be replaced later
- {file} .gitignore
- {file} peereval-Insufficient_RAM-matrom01-v2.csv
- {file} README.md

Once those appear, download the .ZIP file {`Hollow.Bird.zip`} from the attached binaries of any release you wish to work from.
Included should be the project root folder for Unity: "Hollow Bird"

Finally, delete the "Hollow Bird" directory from the `git clone` from the previous step, and replace it with the "Hollow Bird" directory located within the .ZIP file.



### (2) Importing into Unity

Key Items:
- This guide was made with Unity Hub v3.1.2 in mind.
- The game was created with Unity Editor `2020.3.30f1`, but should port easily to later versions.

<br>

Open up Unity Hub, and navigate to the "Projects" tab.

Once there, find the "Open" button with a dropdown arrow to its right. Click the dropdown to open it, and the following two options will appear:
- Add project from disk
- Open remote project

Click "Add project from disk" then navigate to the folder where you cloned the repository at a given release tag.

At this point, you should have the full Unity project root with all the assets and scripts, along with Git properly set up to watch for changes. If you do not, please follow the instructions above labeled `(1) Getting your workspace ready`.

Click on the "Hollow Bird" folder that replaced the `git clone` version, and import it into Unity Hub.

Once you've done all that, you are fully ready to begin working right where we left off! 🎉

---


## HOW TO RUN ME AS A USER

> There is no way to create the binaries on your own as the only files managed by Git and uploaded to the repository are the Scripts for in-game functionality, not the actual scenes or assets to create and build the project on one's own.

1. Unzip the DEMO3.zip folder using your favorite zip manager; WinRAR or 7zip will do just fine.

2. Double-click into the extracted folder.

3. Double-click the `Starting2D.exe` executable, and have fun! All files are configured by Unity, and all the necessary libraries are ready to go!

---

## The core mechanics of the game are centered around surviving and escaping from an unknown forest location filled with enemies, and even worse: the environment.<br><br>Key elements players will need to be mindful of include:

### One

> A fixed inventory system in which the player character can only carry so many items. Players will need to manage storage and take only what they deem important at the time. Items will be useful in some cases, and useless in others.

### Two

> Combat is turn-based, this includes all major and minor encounters with enemies or possible groups of enemies, i.e. a pack of wolves.

### Three

> Random encounters, these fall in two categories; nature and wildlife. Nature encounters will maintain simplicity such as weather interactions. For example, rain may decrease player movement speed. Wildlife encounters are the main priority, in which the player may encounter hostile animals which will increase in intensity. “Rooms” will be sections of the forest, a room is considered cleared if all enemies have been cleared, however it is possible enemies can respawn. This encourages the player to constantly keep moving forward.

### Four

> Player status; for time and scope purposes, player status will fall into health and hunger. Health can decrease in combat situations and increase overtime. Hunger will drop from the player taking actions.

### Five

> Player choices, this works in correlation with inventory management as well as which actions to take in hostile encounters. Something of note is that certain choices are only optional based on previous choices, i.e. weapons you can use for encounters. Milestone progression will govern how the story and game moves forward for the player. At the start of the game, there will likely be one type of enemy with lower spawn rates, and increase in intensity after defeating set mini-bosses. Spawning rates will increase as well as stronger enemies.

---

### "Hollow Bird" is the project's current code-name :: [Explore the Source Code](./Hollow%20Bird)

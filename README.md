# OcarinaMultiworld

> Notice: This project is currently in development. Take this README file with a grain of salt until I publish a release.

OcarinaMultiworld is an alternative Multiworld implementation for the Legend of Zelda: Ocarina of Time Randomizer. Inspired by [Berserker's Multiworld](https://github.com/Berserker66/MultiWorld-Utilities) for the Legend of Zelda: A Link to the Past Randomizer.

## Differences between OcarinaMultiworld and the Official Co-Op Lua Script

- OcarinaMultiworld is a standalone program that handles all processing of game data and communications with the central server. It includes a simple lua script to allow this program to interface with Bizhawk.
- All players are not required to have the emulator and script running in order to play together. Locations and items are synchronised with a central server that keeps track of these events and will update players when they connect.
- When items are received from other players, the OSD (on screen display) built into BizHawk will display the name of the player that sent the item.
- OcarinaMultiworld servers track all items and locations players have been.

## Why make this project?

Because I wanted a way to play this randomizer asynchronously with my friends and found the official script to be frustrating to deal with. Props to [TestRunnerSRL](https://github.com/TestRunnerSRL) for writing the lua script that makes it possible though. I do not have the patience to write a working multiworld implementation completely in lua (a language that I personally find restrictive).

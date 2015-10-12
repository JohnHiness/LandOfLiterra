# Land of Literra
A text-based online RPG. Written in Python and C#.
Originally an idea I had a long time ago, turned into a school project.

##### Technical
The whole idea of how I plan on making this, is that everything will be runned and controlled from the server, meaning that with the clients being so versatile and controllable from the server, all updates will only have to go through the server without clients having to update their software.
There will be multiple servers clients can connect to, and serverlists are downloaded from one of Literra's admin's servers everytime the client loads. The remote location for the serverlist is currently hardcoded into the client, but will likely later be configurable by any admin of a server.

##### Game
The game itself will feature a large map with many quests, items, buildings, arenas, and other entities. Players will be interactable with eachother, not just by chat but also "physically". If any player afflict the world in any way, the changes will be for all other players too. Think of an Elder Scrolls game - textbased and online.

###### Duels and PvP
There will be two ways to fight in this game. The reason for this is because the first way can easily become unfair due to multiple factors. The first way being that, say in order to attack an opponent, one would write "use sword on player". But seeing this will be bad for people with high ping and slow type-speed, a second option was needed without removing the first one being intense and making the game more exiting.
The second way of fighting will be simply turnbased. This way, one can have a fair fight(..if we disregard any random-factors in e.g. damagemultipliers).

###### Map
Maps will be single files on the servers with the ability to load custom maps into the server. Being the maps are solely on the server, they can be updated and expanded at anytime, and perhaps one day, even with the players logged on and the server running.

Oh and by the way, "literra" means "letters" in latin, - "letters" as in characters, not messages.

## License

The MIT License (MIT)

Copyright (c) 2015 John Hiness

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

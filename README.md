# lou-mapinfo
Manipulate data directly from Lord Of Ultima 

*Current Version:* 4.5.1 

[LoU Map Info Online Beta](http://www.loumapinfo.com)


----
A couple months ago, I made a tool that took data from http://www.lou-map.com/ and use it to make summary reports about people, alliance and continent. You could also see all the lawless cities in one click and some useful info about shrines. 

Since the *Forge Of Virtue* update, they incorporated a map with the game, so lou-map.com started to update less and less weeks after weeks. The info used by my App could be then 1 week old even more. So, I started too look elsewhere to have more accurate data.

To make it work, you need the .Net Framework 2.0 on Windows. Some have made it work with mono, but only the "old way" work, Mono is disliking connecting on the game.

So, enjoy :)

*Please note* that the loading is entirely cached. If you load the lawless or moongate or continent overview, this could be a long process the first time, but will be instant after that. The down side is that if you want refreshed info, you need to quit the application. I will work something for that for the next release.
----

# <p align=center>FAQ</p>

<p align=center>*Should I be worried about giving my e-mail and password ?*<br />
Well, you should always verify where you write those things. In this case, you can read the open-source code and see for yourself that I only use it to retrieve a sessionId.</p>

<br />
<p align=center>*Why the animated loading image is going counter-clockwise ? It's driving me crazy !*<br />
It's killing me too, but I made this image a while ago and too lazy to do it again :)</p>

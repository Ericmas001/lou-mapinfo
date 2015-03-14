
---

# <p align='center'>3.1 => 4.0 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=50'>R50</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=82'>R82</a>) 2011-02-26</p> #
  * **FIX**
    * On Alliance report, you were getting total score of a player instead of continent score
    * The "Alliance" section was looking weird if you are not in an alliance.
    * The Lawless & Moongate reports are removed. They didn't work since last LoU Update.

  * **The interface got a total new lifting !!**
    * Sections "LoU Official", "lou-map", "Zeus" and "Tools" are now clearly defined
    * The about & FAQ page is now better than a simple MessageBox
    * Picking a continent is now easier with the new ContinentPicker Window

  * It's now possible to connect with SessionID instead of Mail&Password if you want, both way are available.
  * A new "Zeus" section is available. As long Zeus is listening, you can register, connect, request password and change your password. It's only the beginning !
  * Under the "LoU Official > Alliances" section, you can now produce a CSV listing cities of the alliance on each continent.

**Please note** that the Zeus section is there for testing purpose only. It requires that Zeus is up and running and for now it is pretty unlikely.


---

# <p align='center'>3.0 => 3.1 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=46'>R46</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=50'>R50</a>) 2011-01-29</p> #
  * It's now possible to connect again to the App. Sorry about that, but last released changed everything ! Thanks to Nateural for the tip !
  * No need to have a browser open to use the App anymore.
  * Lawless cities reports are now available.
  * MoonGates location reports are now available.

**Please note** that the loading is entirely cached. If you load the lawless or moongate or continent overview, this could be a long process the first time, but will be instant after that. The down side is that if you want refreshed info, you need to quit the application. I will work something for that for the next release.

---

# <p align='center'>2.2 => 3.0 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=32'>R32</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=46'>R46</a>) 2011-01-02</p> #
  * A new LIVE tab is available, whitch query LoU directly instead of lou-map.
    * It use your LoU credentials to retrieve a sessionID. The application then became aware of who you are.
    * Knowing who you are, it's easy to provide quick links to your information, your alliance or the continent where you have cities.
    * PlayerOverview, AllianceOverview and ContinentOverview are the only reports available in LIVE mode.
    * In those reports, you are aware if it's a land-based city or a water-based city
    * You can also see palaces ! They are bonded with "Castles" everywhere, so "Castle Only" means "Castle and Palace".
    * You can see all the players without any alliance on each continent.

  * Three new icons are visible at the top-right of the application. Options are not available, but Help! and About! are there (but not pretty at all :D)

The important point is that I'm now independant from lou-map and I can provide accurate up-to-date information.
Lawless and Shrine reports are for now not available.
I'm also aware that the report window is not perfect (you can't see palaces without castles, sometimes there is a "Detail level" between "Detailed" and "Summary" that you can't have.

---

# <p align='center'>2.1 => 2.2 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=28'>R28</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=32'>R32</a>) 2010-12-13</p> #
  * **FIX**
    * Lawless cities are no more all in the "Castle" group even if they weren't castled
    * In the Alliance report, your will no more see players without any cities of the interesting type
    * Shrine reports now have the useful info about player and alliance back on track!
    * Report BBCode section now provide the "CTRL+A" shortcut again.
    * Report Window Title for Player & Alliance Report have no more ugly BBCode :)

  * The Continent & World selection is changed, it looks better, it's easier to use and there is no more useles "Load" button.

---

# <p align='center'>2.0 => 2.1 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=21'>R21</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=28'>R28</a>) 2010-12-01</p> #
  * **FIX**
    * The "last updated" information was lost between 1.3 and 2.0, it's back
    * World reports are now using the same report system so you can shape them as well.

  * The Report window got a new interface, with a lot of change
    * Tabs between Report and BBCode are now at bottom and use the new Chrome-like design
    * Choosing between City/Castle/Both and Global/Summary/Detail can be made directly in the report window.
    * You can now Activate/Deactivate 7 display option to shape your report as you like
    * You can select witch BBCode you want to display, so posting on forum with Char limit is less painful.

  * Every setting you make is now persistant, so you wont have to select your fav continent everytime or remake your Display settings, everything is saved.

---

# <p align='center'>1.3 => 2.0 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=16'>R16</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=21'>R21</a>) 2010-12-01</p> #
  * Total new Interface. No more big ugly buttons. Grid and Actions are in the same tab !
  * Using different data files, for more consistency. No more player in the wrong alliance.
  * Total new way of doing report, you won'T see much changes, but they work differently and you have more control (city/Castle/Both & Detail level).
  * Reports now provide Count information.
  * Grid can be filtered city/Castle/Both

---

# <p align='center'>1.2 => 1.3 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=14'>R14</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=16'>R16</a>) 2010-11-30</p> #
  * **FIX**
    * BBCode section, the "Copy all" button wasn't working
    * BBCode section, the "CTRL+A" shortcut to select all wasn't working
    * If there was no lawless city, asking the report would crash the application
    * If lou-map data wasn't accurate about the alliance of lawless city, some lawless didn't appear in the report

  * The "Castle Only" and the "All Cities" reports have been removed. You can have them using "Continent Overview" and selecting if you want Cities, Castles or Both.
  * The Shrines report now display the closest cities to shrines and moongate (3 tiles radius) and allow you to select if you want Cities, Castles or Both.
  * The Player & Alliance report now allow you to select if you want Cities, Castles or Both.

---

# <p align='center'>1.1 => 1.2 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=13'>R13</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=14'>R14</a>) 2010-11-29</p> #
  * New Per-Continent report: You can generate Per-Continent-Shrines report
  * New Per-World report: You can generate Per-World-Alliance report
  * Reports now have a BBCode version available

---

# <p align='center'>1.0 => 1.1 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=12'>R12</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=13'>R13</a>) 2010-11-29</p> #
  * When a continent is loaded, if you ask to load it back it takes the one in cache.
  * YNew Per-Continent report: You can generate Per-Continent-AllCities report
  * New Per-World report: You can generate Per-World-Player report
  * Application now use LoU Icon
<p align='center'><a href='ScreenShots11.md'>Screenshots</a></p>

---

# <p align='center'>0 => 1.0 (<a href='https://code.google.com/p/lou-mapinfo/source/detail?r=1'>R1</a> => <a href='https://code.google.com/p/lou-mapinfo/source/detail?r=12'>R12</a>) 2010-11-28</p> #
  * You can View All continent info in a sortable Table
  * You can generate Per-Continent-Lawless report
  * You can generate Per-Continent-Castles report
  * Use LoUMap data.
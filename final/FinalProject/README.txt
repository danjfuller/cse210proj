Orbital Collision Simulator v1.1
Created by Daniel Fuller, July 2023

Orbital Collision Simulator presents a cross-platform graphical user interface that simulates the orbit of satellites around Earth.
Since space junk has become more of a focus, this program will highlight satellites that pass within a pixel-sized space of each other.
This is representative of a situation where satellites could pass in close proximity to each other.

## Startup
The folder must be downloaded and built for debugging,
OR
Download from https://github.com/danjfuller/cse210proj/tree/main/final/OrbitalCollisions_v1.1 for a built version (requires .net 7.0 on your computer).

When the program starts, the terminal will open and show informational text, which will read similar to this:
Orbital Collision Simulator v1.1

Brief Intro: 
-Satellites are marked in RED
-Planets and other circulate bodies are marked in BLUE
-Satellites that pass very close to another (within a
 pixel distance) are marked as GREEN while this happens
-NOTE: Both this Terminal and the GUI program show information.

The program will then ask for the number of satellites that you wish to simulate. Give an integer number between 1 and 99. The default value of 10 will be used if what is entered is blank.

The program will then list an initial velocity for each satellite, which is randomly placed every time.

The time scaling (how many seconds are simulated in the program for every second on the computer clock) will then be listed, (v1.1 is 666.66 seconds, by mere happenstance).
The program will then ask for the scaling that you prefer (default scaling is 100 kilometers per pixel, which will happen if the user presses enter without putting any number in).
The program will then open a window (created using GTK#, whose logo you may recognize as the icon) showing a blue planet, representing Earth, at the center of the screen. The afforementioned satellites will be placed in orbit around it.

The program will plot trajectories for each satellite.

Setting the initial scaling to 800 will allow enough scaling that users can see the moon (another blue circle) orbiting around the Earth at the center.

## License

Created Using Gtk# by a student at Brigham Young University, Idaho. For Educational Use only.
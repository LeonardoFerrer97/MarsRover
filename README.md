# MarsRover

After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Rover
to further investigate the surface. You are responsible for developing an API that will allow
the Rover to move around the planet. As you won’t get a chance to fix your code once it is
onboard, you are expected to use test driven development.
To simplify navigation, the planet has been divided up into a grid. The rover's position and
location is represented by a combination of x and y coordinates and a letter representing
one of the four cardinal compass points. An example position might be 0, 0, N, which
means the rover is in the bottom left corner and facing North. Assume that the square
directly North from (x, y) is (x, y+1).
In order to control a rover, NASA sends a simple string of letters. The only commands you
can give the rover are ‘F’,’B’,’L’ and ‘R’

#Testing
Two ways of testing the system, one by Unit Tests and the other using the console of Visual Studio

#Input
The first lines that appear on console are simple lines explaining what to do>

"Hello, welcome to the mars rover interface, where you can move the rover around mars!
First you will write the initial position of the machine, where we only accept positive numbers and the four usual direction(N,E,S,W) that will be where the little guy will be looking to!
So... lets start!"

The next lines will be the time that the user will set the first position where the Mars Rover will start 
Example: 0 0 N, this case facing North

Next, the user will set all the moviments available for the mars rover.

And finally, the program will show where the mars rover finished walking.

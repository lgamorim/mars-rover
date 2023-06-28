# Mars Rover
_My solution in .NET/C# for the Mars Rover coding challenge._

A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which
is curiously rectangular, must be navigated by the rovers so that their on-board cameras can get
a complete view of the surrounding terrain to send back to Earth.

A rover’s position and location are represented by a combination of _x_ and _y_ coordinates and a
letter representing one of the four cardinal compass points. The plateau is divided up into a grid
to simplify navigation. An example position might be _(0, 0, N)_, which means the rover is in the
bottom left corner and facing North.

In order to control a rover, NASA sends a simple string of letters. The possible letters are _‘L’_, _‘R’_
and _‘M’_. The _‘L’_ and _‘R’_ letters make the rover spin 90 degrees left or right, respectively, without moving from
its current spot. The _‘M’_ letter moves the rover forward one grid point, maintaining the same heading.
Assume that the square directly North from _(x, y)_ is _(x, y+1)_.

**Input**

+ The first line of input is the upper-right coordinates of the plateau. The lower-left
  coordinates are assumed to be _(0, 0)_.
+ The rest of the input is information pertaining to the rovers that have been deployed.
  Each rover has two lines of input: the first line gives the rover’s position, and the second
  line is a series of instructions telling the rover how to explore the plateau.
+ The position is made up of two integers and a letter separated by spaces, corresponding
  to the _x_ and _y_ coordinates and the rover’s orientation.
+ Each rover will be finished sequentially, which means that the second rover won’t start to
  move until the first one has finished moving.

**Output**

+ The output for each rover should be its final coordinates and heading.

## Example
Below is an example to illustrate the expected output for a given input to this program.

**Input**

5 5\
1 2 N\
LMLMLMLMM\
3 3 E\
MMRMMRMRRM

**Output**

1 3 N\
5 1 E

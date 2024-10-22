# RubikCubeChallenge

## Description
The Rubik's Cube Challenge is a .NET-based project designed to simulate a Rubik's Cube and perform various operations on it. The project provides a representation of the cube's faces and simulates standard Rubik's Cube moves, enabling you to implement and test solving algorithms. 

## Features
- **CubeFace Representation:** Represents each face of the cube in a flat 2D view using an XY axis.
- **Cube Class:** Supports standard Rubik's Cube move notations (U, D, L, R, F, B and their counter-clockwise versions).

## Getting Started
To get started with the Rubik's Cube Challenge in .NET, follow these steps:

1. **Clone the Repository:**
   `git clone https://github.com/oisezrg/RubikCubeChallenge.git`

2. Open the Project: Open the solution file (RubiksCubeChallenge.sln) in Visual Studio or your preferred .NET IDE.

3. Build the Solution: Ensure that all dependencies are restored, and build the solution.

4. Run the Application: Execute the application to start interacting with the Rubik's Cube.

## Cube class
The Cube class represents the entire Rubik's Cube built from six CubeFace instances:

* Responsible for performing actions on the cube, such as rotations and edge movements.
* Supports move notation like U (Up), D (Down), L (Left), R (Right), F (Front), and B (Back) as well as their anti-clockwise versions (e.g., U__).

## CubeFace Representation

The `CubeFace` class describes a single face of the Rubik's Cube in a flat 2D representation using the XY axis:

The Rubik's Cube has six faces, each represented by 9 fields.
Each tile in the grid corresponds to a sticker on the cube, identified by a color (e.g., 'White', 'Red', 'Blue').
The grid layout follows the XY coordinate system in flat view (https://rubiks-cube-solver.com/).
```
   ┌────────────────────────────────────────────────────────────────────┐
   │ LeftTop		CenterTop		RightTop		│
   │ LeftCenter		CenterCenter		RightCenter		│
   │ LeftBottom		CenterBottom		RightBottom		│
   └────────────────────────────────────────────────────────────────────┘
```
## Performing Moves

Moves can be applied using the Cube class:

```
Cube cube = provider.GetRequiredService<ICube>();
cube.U();		// clockwise	
cube.R_();		// anti clockwise
```

## Contributing
Contributions are welcome! Please submit issues, feature requests, or pull requests to help improve this project.

## License
This project is licensed under the MIT License.
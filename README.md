# Dot Product Examples

A small Unity project that demonstrates how the dot product can measure the alignment between directions.

## Requirements

- Unity 6000.6.0f1

## Examples

- **Simple Compass** - Compares the player's forward direction with the direction to a target to show whether the player is facing it.
- **Search Angle** - Visualizes a configurable search cone and uses dot products to measure the alignment of its boundary directions.
- **Simple Cel Shader** - Uses the result of the Dot product between the normals of a mesh and the light direction to get simple lighting

## Running the examples

Open `Assets/Scenes/SampleScene.unity` and enable Gizmos in the Scene window. Move or rotate the objects to see the direction vectors and dot-product results update in real time.

The example scripts are in `Assets/Scripts`.

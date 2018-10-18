# Optically Realistic Water
A Unity port of Martins Upitis' fantastic [ocean water shader](https://devlog-martinsh.blogspot.com/2013/09/waterunderwater-sky-shader-update-02.html), which was originally coded in GLSL for Blender.

![water](https://user-images.githubusercontent.com/5405629/47149964-7a570800-d318-11e8-9420-74cf4619b35e.jpg)

## Contents
The shader actually consists of two parts:
* WaterSurface.shader
* WaterUnder.shader

WaterSurface.shader is intended to be used with the water plane and renders reflections, subsurface scattering, etc.

WaterUnder.shader must be applied to any renderers which could potentially be submerged in the water (such as the terrain, etc.).

Water.cs should be attached to the water plane and handles planar reflections and all shader parameters. It is mostly self-explanatory if you are at all familiar with Unity's existing water shader.

Just like in Martins' project, you can click and drag the sun into any position you like.

## Features
* Reflection with accurate fresnel reflectance model
* Refraction with chromatic aberration
* Projected caustics on geometry from the water surface based on normals
* Seamless transition to underwater (no post effects used)
* Accurate water volume with light scattering
* View and light ray color extinction based on water color and sunlight

## Additional features/changes
* Refraction is masked based on depth to prevent foreground distortion artefacts
* Normal map intensity fades out with distance to prevent excessive distortion artefacts
* Clip plane offset depends on camera distance from water plane, which reduces artefacts when close to surface
* Some shader calculations moved into scripts (sun colour, for example)
* Some optimisations (much more could be done here)

## Removed/unported features
* Simple coastline detection (I didn't want this shader to rely on baked shoreline maps)
* "Caustic fringe" effect
* Above/below water transition droplet post effect
* Underwater distortion (it's not a real physical phenomenon so I chose to remove it)
* "Glitter" post effect

## Limitations
Due to the required underwater shader, you may find it very difficult to adapt this to an existing project and thus it should be considered more of a prototype or proof of concept. This is also a limitation of Martins' original shader.

The shader uses forward rendering and has not been tested in deferred.

using System;
using UnityEngine;

[Serializable]
public class WaterSettings
{
	public static WaterSettings Default => new WaterSettings
	{
		normalTexture = null,
		windDirection = new Vector2(-.5f, -.8f),
		windSpeed = .6f,
		visibility = 28f,
		waveScale = 1f,
		scatterAmount = 3.5f,
		scatterColor = new Color(0, 1f, .95f, 1),
		reflectionDistortionAmount = .03f,
		refractionDistortionAmount = .04f,
		aberrationAmount = .002f,
		mudExtinction = new Color(1f, .7f, .5f),
		waterExtinction = new Color(.6f, .8f, 1f),
		sunExtinction = new Color(.45f, .55f, .7f)
	};
		
	public Texture2D normalTexture;
	public Vector2 windDirection;
	public float windSpeed;
	public float visibility;
	public float waveScale;
	public float scatterAmount;
	public Color scatterColor;
	public float reflectionDistortionAmount;
	public float refractionDistortionAmount;
	public float aberrationAmount;
	public Color mudExtinction;
	public Color waterExtinction;
	public Color sunExtinction;
}
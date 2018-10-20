using UnityEngine;

public static class WaterUtility
{
	public static Vector3 ToVector3(this Color c) => new Vector3(c.r, c.g, c.b);
	
	public static Vector3 GetTransmittance(Vector3 lightDir, Vector3 lightExtinction)
	{
		float y = lightDir.y;
		
		return new Vector3
		{
			x = Mathf.Max(1 - Mathf.Exp(y * lightExtinction.x), 0),
			y = Mathf.Max(1 - Mathf.Exp(y * lightExtinction.y), 0),
			z = Mathf.Max(1 - Mathf.Exp(y * lightExtinction.z), 0)
		};
	}
}
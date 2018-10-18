using UnityEngine;

[ExecuteInEditMode]
public class LightGrab : MonoBehaviour
{
	[SerializeField]
	Color extinction = new Color(.45f, .55f, .7f);
	
	[SerializeField]
	Color noonColor = Color.white;

	[SerializeField]
	Color duskColor = new Color(1f, .5f, .2f);
	
	bool grabbing;
	Quaternion startRot;
	Quaternion camRot;
	
	void Update()
	{
		#if UNITY_EDITOR
		if(Application.isPlaying)
		#endif
		{
			if(Input.GetMouseButtonDown(0))
			{
				grabbing = true;
				startRot = transform.rotation;
				camRot = Camera.main.transform.rotation;
			}

			if(grabbing)
			{
				if(Input.GetMouseButtonUp(0))
				{
					grabbing = false;
				}

				transform.rotation = Quaternion.Inverse(camRot * Quaternion.Inverse(Camera.main.transform.rotation)) * startRot;
			}
		}

		var light = GetComponent<Light>();
		
		if(light)
			light.color = GetLightColor(transform.forward);
	}

	Color GetLightColor(Vector3 lightDir)
	{
		float y = lightDir.y * 5;
		
		Color sunPenetration = new Color
		{
			r = Mathf.Max(1 - Mathf.Exp(y * extinction.r), 0),
			g = Mathf.Max(1 - Mathf.Exp(y * extinction.g), 0),
			b = Mathf.Max(1 - Mathf.Exp(y * extinction.b), 0)
		};

		return new Color
		{
			r = Mathf.Lerp(duskColor.r, noonColor.r, sunPenetration.r),
			g = Mathf.Lerp(duskColor.g, noonColor.g, sunPenetration.g),
			b = Mathf.Lerp(duskColor.b, noonColor.b, sunPenetration.b)
		};
	}
}
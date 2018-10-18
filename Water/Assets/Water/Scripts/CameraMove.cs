using UnityEngine;

public class CameraMove : MonoBehaviour
{
	void Update()
	{
		transform.Rotate(-Input.GetAxisRaw("Mouse Y") * 2, 0, 0, Space.Self);
		transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 2, 0, Space.World);
		
		transform.Translate(Input.GetAxis("Horizontal") * Time.smoothDeltaTime * 10, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * 10, Space.Self);
	}
}
using UnityEngine;

public class RaisingLava : MonoBehaviour
{
	[Tooltip ("Game units per second")]
    [SerializeField] float scrollRate = 0.3f;

	private void Update()
	{
		transform.Translate(Vector2.up * Time.deltaTime * scrollRate);
	}
}

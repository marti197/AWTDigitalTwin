namespace Mapbox.Examples
{
	using UnityEngine;
	using UnityEngine.EventSystems;
	using Mapbox.Unity.Map;

	public class CameraMovement : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		float _panSpeed = 20f;

		[SerializeField]
		float _zoomSpeed = 50f;

		[SerializeField]
		Camera _referenceCamera;

		Quaternion _originalRotation;
		Vector3 _origin;
		Vector3 _delta;
		bool _shouldDrag;

		

		void ZoomMapUsingTouchOrMouse(float zoomFactor)
		{
			var y = zoomFactor * _zoomSpeed;
			transform.localPosition += (transform.forward * y);
		}

		void HandleMouseAndKeyBoard()
		{
			if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
			{
				var mousePosition = Input.mousePosition;
				mousePosition.z = _referenceCamera.transform.localPosition.y;
				_delta = _referenceCamera.ScreenToWorldPoint(mousePosition) - _referenceCamera.transform.localPosition;
				_delta.y = 0f;
				if (_shouldDrag == false)
				{
					_shouldDrag = true;
					_origin = _referenceCamera.ScreenToWorldPoint(mousePosition);
				}
			}
			else
			{
				_shouldDrag = false;
			}

			if (_shouldDrag == true)
			{
				var offset = _origin - _delta;
				offset.y = transform.localPosition.y;
				transform.localPosition = offset;
			}
			else
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					return;
				}

				//var x = Input.GetAxis("Horizontal");
				//var z = Input.GetAxis("Vertical");
				//var y = Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
				//if (!(Mathf.Approximately(x, 0) && Mathf.Approximately(y, 0) && Mathf.Approximately(z, 0)))
				//{
				//	transform.localPosition += transform.forward * y + (_originalRotation * new Vector3(x * _panSpeed, 0, z * _panSpeed));
				//	_map.UpdateMap();
				//}
                // Ignore Horizontal and Vertical axis
                var y = Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
                if (!(Mathf.Approximately(y, 0)))
                {
                    transform.localPosition += transform.forward * y;
                    _map.UpdateMap();
                }
            }


		}

		void Awake()
		{
			_originalRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

			if (_referenceCamera == null)
			{
				_referenceCamera = GetComponent<Camera>();
				if (_referenceCamera == null)
				{
					throw new System.Exception("You must have a reference camera assigned!");
				}
			}

			if (_map == null)
			{
				_map = FindObjectOfType<AbstractMap>();
				if (_map == null)
				{
					throw new System.Exception("You must have a reference map assigned!");
				}
			}
		}

		void LateUpdate()
		{

			
				HandleMouseAndKeyBoard();
			
		}
	}
}
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;


    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 5f;

    [Header("Camera Settings")]
    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;

    public bool cameraDisabled = true;

    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }

    //Late Update is called once per frame, after Update() on every game object in the scene.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraDisabled = !cameraDisabled;
        }

        if (!cameraDisabled)
        {
            //Rotation based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                //Clamp the y Rotation to horizon and not flipping over
                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, -45f, 45f);
            }

            //Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                //Makes camera zoom faster the further away it is from the target
                scrollAmount *= (this._CameraDistance * 0.3f);

                this._CameraDistance += scrollAmount * -1f;

                //This makes camera go no closer than x meters from target, and no further than x meters.
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 8f);
            }
        }

        //Actual Camera Rig Transformations
        Quaternion qT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, qT, Time.deltaTime * orbitDampening);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }
}

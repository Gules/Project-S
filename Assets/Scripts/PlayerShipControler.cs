using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerShipControler : MonoBehaviour
    {
        public float TurnSpeed = 1;
        public float ForewardSpeed = 1;


        private GameObject ship;
        private KeyMap keyMap;
        private GameObject sceneScripts;

        private void Start()
        {
            sceneScripts = GameObject.Find("/SceneScripts");
            keyMap = sceneScripts.GetComponent<KeyMap>();
            ship = this.transform.gameObject;
        }
        private void FixedUpdate()
        {
            if (Input.GetKey(keyMap.TurnLeft))
            {
                ship.GetComponent<Rigidbody2D>().AddTorque(TurnSpeed);
            }
            if (Input.GetKey(keyMap.TurnRight))
            {
                ship.GetComponent<Rigidbody2D>().AddTorque(-TurnSpeed);
            }
            if (Input.GetKey(keyMap.Foreward))
            {
                ship.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * ForewardSpeed);
            }
            if (Input.GetKey(keyMap.TurnAround))
            {
                Vector2 forwardVector = ship.transform.up;
                float angle = Vector2.Angle(forwardVector, -ship.GetComponent<Rigidbody2D>().velocity);
                if (Vector3.Cross(forwardVector, -ship.GetComponent<Rigidbody2D>().velocity).z < 0)
                {
                    ship.GetComponent<Rigidbody2D>().AddTorque(-TurnSpeed);
                }
                else
                {
                    ship.GetComponent<Rigidbody2D>().AddTorque(TurnSpeed);
                }
            }
            
        }
    }
}
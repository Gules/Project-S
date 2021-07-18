using UnityEngine;

namespace Assets.Scripts.Player
{
    [DisallowMultipleComponent]
    public class PlayerShipControler : MonoBehaviour
    {
        [Tooltip("The Speed that the ship turns (Recommend: Mass MULTIPLIED (20 for fast <Drones, Interceptors, Strike Craft> || 10 for medium <Escort, Cargo, Destroyer> || 5 for slow <Battleships, Dreadnoughts, Capital>)")]
        public float TurnSpeed;

        [Tooltip("The Speed that the ship accelerates (Recommend: Mass MULTIPLIED (2 for fast <Drones, Interceptors, Frigate> || 1 for medium <Escort, Cargo, Destroyer> || .5 for slow Battleships, Dreadnoughts, Capital)")]
        public float ForewardSpeed;

        [Tooltip("The maximum speed that the ship is allowed to move (Recommend: 5 => Smaller fast ships <Drones, Interceptors, Strike Craft> || 2.5 => Medium slower ships <Escort, Cargo, Destroyer> || 1 => Larger slow ships <Battleships, Dreadnoughts, Capital>)")]
        public float MaxSpeed = 20;

        private GameObject ship; //The Player ship
        private KeyMap keyMap; //The KeyMap Script
        private GameObject sceneScripts; //The SceneScript GameObject

        private void Start()
        {
            sceneScripts = GameObject.Find("/SceneScripts"); //Finds the game object in the Hierarchy called "SceneScripts"
            keyMap = sceneScripts.GetComponent<KeyMap>(); // In SceneScripts gets the script called "KeyMap"
            ship = this.transform.gameObject; //Defines the players ship
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(keyMap.TurnLeft)) //If the TurnLeft key is pressed
            {
                ship.GetComponent<Rigidbody2D>().AddTorque(TurnSpeed); //Rotates the ship to the Left
            }
            if (Input.GetKey(keyMap.TurnRight)) //If the TurnRight key is pressed
            {
                ship.GetComponent<Rigidbody2D>().AddTorque(-TurnSpeed); //Rotates the players ship to the right
            }
            if (Input.GetKey(keyMap.Foreward)) //If the Forward key is pressed
            {
                if (ship.GetComponent<Rigidbody2D>().velocity.magnitude < MaxSpeed) //If the ship's velocity is less than the ships max speed
                {
                    ship.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * ForewardSpeed); //Accelerate the car
                }
                else
                {
                    ship.GetComponent<Rigidbody2D>().velocity *= .9999f; //Otherwise keep the speed the same
                }
            }
            if (Input.GetKey(keyMap.TurnAround)) //If the turnAround key is pressed
            {
                Vector2 forwardVector = ship.transform.up; //Get the local up direction
                if (Vector3.Cross(forwardVector, -ship.GetComponent<Rigidbody2D>().velocity).z < 0) //If the cross product of the forward vector and the negative velocity is greater less than 0
                {
                    ship.GetComponent<Rigidbody2D>().AddTorque(-TurnSpeed); //Turn the ship to the right
                }
                else
                {
                    ship.GetComponent<Rigidbody2D>().AddTorque(TurnSpeed); //Turn the ship to the left
                }
            }
        }
    }
}
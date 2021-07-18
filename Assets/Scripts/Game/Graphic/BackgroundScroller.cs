using UnityEngine;

namespace Assets.Scripts.System
{
    public class BackgroundScroller : MonoBehaviour
    {
        public float Parallax;
        public GameObject Player;

        private void Update()
        {
            MeshRenderer background = GetComponent<MeshRenderer>(); //Get the MeshRenderer component
            Material mat = background.material; //Get the material from the MeshRenderer
            Vector2 offset = mat.mainTextureOffset; //Get the mainTextureOffet property from the material
            {
                offset.x = this.transform.position.x / transform.localScale.x / Parallax; //Set the X offset to the global x position DIVIDED by the local scale DIVIDED by the PUBLIC float "Parallax"
                offset.y = this.transform.position.y / transform.localScale.y / Parallax; //Set the X offset to the global y position DIVIDED by the local scale DIVIDED by the PUBLIC float "Parallax"
            }

            mat.mainTextureOffset = offset; //Sets the mainTextureOffset
        }
    }
}
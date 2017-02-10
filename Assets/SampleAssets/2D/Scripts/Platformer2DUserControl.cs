using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using UnityEngine.UI;
namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private Button btnKiri, btnKanan, btnAtas, btnBawah;
        public AudioSource jumpsfx;
        bool crouch;
        float h;
        private PlatformerCharacter2D character;
        private bool jump;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                jump = CrossPlatformInputManager.GetButtonDown("Jump");

            }
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            crouch = Input.GetKey(KeyCode.LeftControl);
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            character.Move(h, crouch, jump);
            jump = false;
        }

        public void setJumpTrue()
        {
            jump = true;
            //jumpsfx.Play();
        }

        public void setJumpFalse()
        {

        }

        public void CrouchDown()
        {
            crouch = true;
        }

        public void CrouchUp()
        {
            crouch = false;
        }

        public void KananDown()
        {
            h = 1.2f;
        }

        public void KiriDown()
        {
            h = -1.2f;
        }

        public void Diam()
        {
            h = 0f;
        }


    }
}
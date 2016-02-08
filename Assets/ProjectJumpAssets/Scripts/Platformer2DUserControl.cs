using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private int flipped = -1;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
			if (CrossPlatformInputManager.GetButtonDown("Flip"))
			{
				// Read the flip input if pressed then reverse flipped
				flipped = flipped * -1;				 
				// Multiply the player's y local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.y *= -1;
				transform.localScale = theScale;
			}

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            //Check horizontal speed based on inputs
            bool left = CrossPlatformInputManager.GetButton("Left");
            bool right = CrossPlatformInputManager.GetButton("Right");
            //hsp is the horizontal speed given as 1 or -1 depending on the buttons pressed
            float hsp = (left ? -1 : 0) + (right ? 1 : 0);
            // Pass all parameters to the character control script.
            m_Character.Move(hsp, crouch, m_Jump, flipped);
            m_Jump = false;
        }
    }
}

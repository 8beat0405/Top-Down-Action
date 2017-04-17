using UnityEngine;
using Spine.Unity;
using UnityStandardAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.

        Vector3 movement;                   // The vector to store the direction of the player's movement.
        private Animator animator;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

		[Header("Graphics")]
		private SkeletonAnimator skeletonAnimator;

        void Awake ()
        {
            // Set up references.
            playerRigidbody = GetComponent <Rigidbody> ();
			GameObject grandChild = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
			animator = grandChild.GetComponent<Animator> ();
			skeletonAnimator = grandChild.GetComponent<SkeletonAnimator> ();
        }

		void Update ()
		{
			
		}

        void FixedUpdate ()
        {
            // Store the input axes.
            float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

            // Move the player around the scene.
            Move (h, v);

			//flip left or right
			if (h > 0) {
				skeletonAnimator.skeleton.flipX = false;
			} else if (h < 0) {
				skeletonAnimator.skeleton.flipX = true;
			}

			if (h == 0 && v == 0) {
				animator.SetBool ("isWalking", false);
				var skeleton = skeletonAnimator.skeleton;
				skeleton.SetToSetupPose ();
			} else {
				animator.SetBool ("isWalking", true);
				var skeleton = skeletonAnimator.skeleton;
				skeleton.SetToSetupPose ();
			}
        }


        void Move (float h, float v)
        {
            // Set the movement vector based on the axis input.
            movement.Set (h, 0f, v);
            
            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition (transform.position + movement);
        }
	}
}
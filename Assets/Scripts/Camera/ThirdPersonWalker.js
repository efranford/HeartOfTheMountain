// ThirdPersonWalker.js
// this script adds two things to the default FPS walker
// - It adds movement forward by holding down both mouse keys
// - and it adds auto animation changing between idle, walk and run
// After adding this script to your controller, drag the character model to Target
var speed = 6.0; // standard running speed
var walkSpeed = .8; // walk speed adjust both for your charcter so feet don't slide on ground
var jumpSpeed = 8.0;
var gravity = 20.0;
var Character: Transform;

var PlayAnimations: boolean = false;
var ShowDebug: boolean = true;

private
var moveDirection = Vector3.zero;
private
var grounded: boolean = false;
// a flag to determine idle vs walking/running (so animations do not get started over and over)
private
var walking: boolean = false;
// a flag to init idle animation at beginning
private
var startup: boolean = true;
// a flag to determine walking vs running
private
var running: boolean = true;
private
var crouching: boolean = true;

function FixedUpdate() {
    if (grounded) {
        // We are grounded, so recalculate movedirection directly from axes
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // if both mouse buttons are down, move forward
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
            moveDirection.z = 1;
        }

        moveDirection = transform.TransformDirection(moveDirection);
        if (running == true) {
            moveDirection *= speed;
        } else {
            moveDirection *= walkSpeed;
        }

        if (Input.GetButton("Jump")) {
            moveDirection.y = jumpSpeed;
            if(PlayAnimations)Character.animation.CrossFade("jump");
            if(ShowDebug)Debug.Log("Jump");
        }

       // auto toggle between idle and walking animations - based on run / walk switch
        if (Character) {
            // toggle between walk and run with <left shift> R
            if (Input.GetKey(KeyCode.LeftShift)) {
                if (running == true) {
                    running = false;
                    if (walking == true && PlayAnimations) Character.animation.CrossFade("walk");
                    if(ShowDebug)Debug.Log("Walk");
                } else {
                    running = true;
                    if (walking == true && PlayAnimations) Character.animation.CrossFade("run");
                    if(ShowDebug)Debug.Log("Run");
                }
            }
            if(Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl))
            {
	            if(crouching == true)
	           		crouching = false;
	            if (crouching && PlayAnimations) Character.animation.CrossFade("Crouch");
	            if(ShowDebug)Debug.Log("Crouch");
            }
            if (startup == true) {
                startup = false;
                if(PlayAnimations)Character.animation.Play("idle");
                if(ShowDebug)Debug.Log("Idle");
            }
            if ((moveDirection == Vector3.zero) && (walking == true)) {
                walking = false;
                if(PlayAnimations)Character.animation.CrossFade("idle");
                if(ShowDebug)Debug.Log("Idle");
            } else {
                if ((moveDirection != Vector3.zero) && (walking == false)) {
                    walking = true;
                    if (running == true) {
                        if(PlayAnimations)Character.animation.CrossFade("run");
                        if(ShowDebug)Debug.Log("Run");
                    } else {
                        if(PlayAnimations)Character.animation.CrossFade("walk");
                        if(ShowDebug)Debug.Log("Walk");
                    }
                }
            }
        }
    }

    // Apply gravity
    moveDirection.y -= gravity * Time.deltaTime;

    // Move the controller
    var controller: CharacterController = GetComponent(CharacterController);
    var flags = controller.Move(moveDirection * Time.deltaTime);
    grounded = (flags & CollisionFlags.CollidedBelow) != 0;
}

@script RequireComponent(CharacterController)
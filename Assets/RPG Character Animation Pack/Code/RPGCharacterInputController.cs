﻿using UnityEngine;

namespace RPGCharacterAnims
{
    public class RPGCharacterInputController:MonoBehaviour
    {
        //Inputs.
        [HideInInspector] public bool inputJump;
        [HideInInspector] public bool inputLightHit;
        [HideInInspector] public bool inputDeath;
        [HideInInspector] public bool inputAttackL;
        [HideInInspector] public bool inputAttackR;
        [HideInInspector] public bool inputCastL;
        [HideInInspector] public bool inputCastR;
        [HideInInspector] public float inputSwitchUpDown;
        [HideInInspector] public float inputSwitchLeftRight;
        [HideInInspector] public bool inputStrafe;
        [HideInInspector] public float inputTargetBlock = 0;
        [HideInInspector] public float inputAimVertical = 0;
        [HideInInspector] public float inputAimHorizontal = 0;
        [HideInInspector] public float inputHorizontal = 0;
        [HideInInspector] public float inputVertical = 0;
        [HideInInspector] public bool inputAiming;
        [HideInInspector] public bool inputRoll;
        [HideInInspector] public bool inputShield;
        [HideInInspector] public bool inputRelax;

        //Variables
        [HideInInspector] public bool allowedInput = true;
        [HideInInspector] public Vector3 moveInput;
        [HideInInspector] public Vector2 aimInput;

        /// <summary>
        /// Input abstraction for easier asset updates using outside control schemes.
        /// </summary>
        private void Inputs()
        {
            inputJump = Input.GetButtonDown("Jump");
         //   inputLightHit = Input.GetButtonDown("LightHit");
            //inputDeath = Input.GetButtonDown("Death");
           // inputAttackL = Input.GetButtonDown("AttackL");
            inputAttackR = Input.GetButtonDown("AttackR");
            //inputCastL = Input.GetButtonDown("CastL");
            //inputCastR = Input.GetButtonDown("CastR");
            //inputSwitchUpDown = Input.GetAxisRaw("SwitchUpDown");
            //inputSwitchLeftRight = Input.GetAxisRaw("SwitchLeftRight");
            //inputStrafe = Input.GetKey(KeyCode.LeftShift);
            //inputTargetBlock = Input.GetAxisRaw("TargetBlock");
            //inputAimVertical = Input.GetAxisRaw("AimVertical");
            //inputAimHorizontal = Input.GetAxisRaw("AimHorizontal");
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
            //inputAiming = Input.GetButton("Aiming");
            //inputRoll = Input.GetButtonDown("L3");
            //inputShield = Input.GetButtonDown("Shield");
            //inputRelax = Input.GetButtonDown("Relax");
        }

        private void Awake()
        {
            allowedInput = true;
        }

        private void Update()
        {
            Inputs();
            moveInput = CameraRelativeInput(inputHorizontal, inputVertical);
            aimInput = new Vector2(inputAimHorizontal, inputAimVertical);
        }

        /// <summary>
        /// Movement based off camera facing.
        /// </summary>
        private Vector3 CameraRelativeInput(float inputX, float inputZ)
        {
            //Forward vector relative to the camera along the x-z plane   
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            //Right vector relative to the camera always orthogonal to the forward vector.
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            Vector3 relativeVelocity = inputHorizontal * right + inputVertical * forward;
            //Reduce input for diagonal movement.
            if(relativeVelocity.magnitude > 1)
            {
                relativeVelocity.Normalize();
            }
            return relativeVelocity;
        }

        public bool HasAnyInput()
        {
            if(allowedInput && moveInput != Vector3.zero && aimInput != Vector2.zero && inputJump != false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasMoveInput()
        {
            if(allowedInput && moveInput != Vector3.zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasAimInput()
        {
            if(allowedInput && (aimInput.x < -0.8f || aimInput.x > 0.8f) || (aimInput.y < -0.8f || aimInput.y > 0.8f))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
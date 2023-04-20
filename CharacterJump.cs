using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class CharacterJump : ScriptableObject, ICaptainCommand
    {
        private float jumpForce = 70.0f;



        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();


            if (rigidBody != null)
            {
                 rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }
}
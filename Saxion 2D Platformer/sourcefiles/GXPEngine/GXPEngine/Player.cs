using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Player : Sprite
    {
        //Allow when the anime sprite is done
        //float frame = 0.0f;
        //int firstFrame = 0;
        //int lastFrame = 2;

        float xSpeed = 0.0f;
        float ySpeed = 0.0f;
        bool hasMoved;

        bool allowJump = false;

        public Player() : base("../../../../First_examplesPics/yellowCube.png")
        {
            this.SetXY(0, game.height - this.width);
        }

        public void Update()
        {
            UpdateControls();
        }

        /*void SetAnimationRange(int first, int last)
        {
            firstFrame = first;
            lastFrame = last;
        }*/

        void UpdateControls()
        {
            ApplySteering();
            ApplyGravity();
        }

        void ApplySteering()
        {
            if (Input.GetKey(Key.D) || Input.GetKey(Key.RIGHT))
            {
                //SetAnimationRange(0, 2);
                Mirror(false, false);
                xSpeed = xSpeed + 1;
            }
            else if (Input.GetKey(Key.A) || Input.GetKey(Key.LEFT))
            {
                //SetAnimationRange(0, 2);
                Mirror(true, false);
                xSpeed = xSpeed - 1;
            }
            else
            {
                //SetAnimationRange(4, 6);
            }
            hasMoved = Move(xSpeed, 0);
            xSpeed = xSpeed * 0.9f;
            if (!hasMoved)
            {
                xSpeed = -xSpeed;
            }
        }

        bool Move(float moveX, float moveY)
        {
            bool notHitWall = true;
            x = x + moveX;
            if (x < 0)
            {
                x = 0;
                notHitWall = false;
            }
            if (x > game.width - 40)
            {
                x = game.width - 40;
                notHitWall = false;
            }
            y = y + moveY;
            if (y < 0)
            {
                y = 0;
                notHitWall = false;
            }
            if (y > game.height - height)
            {
                y = game.height - height;
                notHitWall = false;
                allowJump = true;
            }
            return notHitWall;
        }

        void ApplyGravity()
        {
            hasMoved = Move(0, ySpeed);
            ySpeed = ySpeed + 1;
            //y += ySpeed;
            if (y >= game.height - this.height)
            {
                y = game.height - this.height;
                ySpeed = 0;
                allowJump = true;
            }
            if (allowJump)
            {
                if (Input.GetKeyDown(Key.W) || Input.GetKeyDown(Key.SPACE) || Input.GetKeyDown(Key.UP))
                {
                    ySpeed = -20;
                    allowJump = false;
                }
            }
            y += ySpeed;
        }
    }
}

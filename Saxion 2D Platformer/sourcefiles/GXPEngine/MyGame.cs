using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	
	public MyGame () : base(800, 600, false)
	{
		AddChild(new Level());
	}
	
	void Update () {
		//empty
	}

	static void Main() {
		new MyGame().Start();
	}
}


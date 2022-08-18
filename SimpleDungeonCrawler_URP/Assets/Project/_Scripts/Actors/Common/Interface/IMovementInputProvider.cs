// ######################################################################
// IMovementInputProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;

namespace Project.Actors
{
    public interface IMovementInputProvider
	{
		#region Delegate(s):
		public event Action<Vector2> OnMovementInputEvent;
		#endregion
	}
}
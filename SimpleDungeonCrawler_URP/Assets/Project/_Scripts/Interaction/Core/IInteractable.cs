// ######################################################################
// IInteractable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Interaction
{
    public interface IInteractable
	{
		void Interact(GameObject _interactor);
	}
}

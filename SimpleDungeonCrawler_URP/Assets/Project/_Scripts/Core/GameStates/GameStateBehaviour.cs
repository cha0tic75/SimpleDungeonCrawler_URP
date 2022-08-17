// ######################################################################
// GameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project
{
    public abstract class GameStateBehaviour
	{
		#region Constructor(s):
		public GameStateBehaviour() { }
		#endregion

        #region Public API:
        public abstract void Perform();
        #endregion
	}
}
// ######################################################################
// PlayerHealthStatComponent - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Damage;

namespace Project.Stats
{
    public class PlayerHealthStatComponent : HealthStatComponent, IHealable
	{
		#region Public API:
		public void Heal(int _healAmount) => AlterCurrentValue(_healAmount);
		#endregion
	}
}

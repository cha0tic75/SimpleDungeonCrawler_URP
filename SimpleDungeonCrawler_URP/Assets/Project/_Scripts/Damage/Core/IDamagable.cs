// ######################################################################
// IDamagable - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Stats;

namespace Project
{
	public enum ConsumeType
	{
		Damage, 
		Use
	}
    public interface IDamagable
	{
		StatType_SO StatType { get; }

		void Consume(float _damageAmount, ConsumeType _consumeType);
	}
}

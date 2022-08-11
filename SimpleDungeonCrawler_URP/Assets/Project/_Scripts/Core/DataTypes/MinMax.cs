// ######################################################################
// MinMax - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
	[System.Serializable]
	public abstract class MinMax<T>
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public T Min { get; protected set; }
		[field: SerializeField] public T Max { get; protected set; }
		#endregion

		#region Constructor(s):
		public MinMax() { }
		public MinMax(T _min, T _max)
		{
			Min = _min;
			Max = _max;
		}
		#endregion
	}

	[System.Serializable]
	public class MinMaxFloat : MinMax<float> 
	{
		#region Constructor(s):
		public MinMaxFloat() { }
		public MinMaxFloat(float _min, float _max)
		{
			Min = _min;
			Max = _max;
		}
		#endregion

		#region Public API:
		public float GetRandomValueInRange() => UnityEngine.Random.Range(Min, Max);
		#endregion
	}

	[System.Serializable]
	public class MinMaxInt : MinMax<int> 
	{
		#region Constructor(s):
		public MinMaxInt() {}
		public MinMaxInt(int _min, int _max)
		{
			Min = _min;
			Max = _max;
		}
		#endregion

		#region Public API:
		public int GetRandomValueInRange() => UnityEngine.Random.Range(Min, Max + 1);
		#endregion
	}

	[System.Serializable]
	public class ProbabilityInt : MinMaxInt
	{
		#region Constructor(s):
		public ProbabilityInt() {}
		public ProbabilityInt(int _min, int _max) : base (_min, _max) { }
		#endregion

		#region Public API:
		public bool IsInRange(int _seed) => _seed >= Min && _seed <= Max;
		public static int GetRndProbability() => UnityEngine.Random.Range(0, 100) + 1;
		#endregion
	}
}
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
	#region Fields & Properties
	#region Fields
	[SerializeField] private float fMax;
	private float fCurrent;
	private List<float> fFlatModifier = new();
	private List<float> fMultModifier = new();
	#endregion
	
	#region Properties
	public float Current => (fCurrent + CalculateFlat()) * CalculateMult();
	public float Max => fMax;
	#endregion
	#endregion
	
	#region Methods
	public void Init()
	{
		fCurrent = fMax;
	}

	public void ChangeMax(float _max)
	{
		if (_max < 0)
			_max = 0;
		float _change = _max / fMax;
		fMax = _max;
		fCurrent *= _change;
	}

	public void ChangeCurrent(float _current)
	{
		_current = Mathf.Clamp(_current, 0, fMax);
		fCurrent = _current;
	}
	
	public void AddMax(float _add) => ChangeMax(fMax + _add);

	public void RemoveMax(float _remove) => ChangeMax(fMax - _remove);

	public void AddCurrent(float _add) => ChangeCurrent(fCurrent + _add);
	
	public void RemoveCurrent(float _remove) => ChangeCurrent(fCurrent - _remove);
	
	private float CalculateFlat()
	{
		float _fFinal = 0;

		for (int _i = 0; _i < fFlatModifier.Count; _i++)
			_fFinal += fFlatModifier[_i];

		return _fFinal;
	}
	
	private float CalculateMult()
	{
    		float _fFinal = 1;
    
    		for (int _i = 0; _i < fMultModifier.Count; _i++)
			    _fFinal += fMultModifier[_i];
    
    		return _fFinal;
	}
    #endregion
}

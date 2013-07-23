using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct ModuloEx
{
	private double _a;
	private double _divider;
	private double _multiplicator;
	private double _reste;

	public double A { get { return _a; } }
	public double Divider { get { return _divider; } }
	public double Multiplicator { get { return _multiplicator; } }
	public double Reste { get { return _reste; } }

	public ModuloEx(double a, double divider)
	{
		_a = a;
		_divider = divider;
		_multiplicator = (int)Math.Floor((double)(_a / _divider));
		_reste = _a - (_divider * _multiplicator);
	}

	/*private void Compute(double a, double divider)
	{
		
	}*/
}


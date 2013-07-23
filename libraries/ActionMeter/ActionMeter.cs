using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ActionMeter
{
	private System.Timers.Timer _timer;
	public event Action<decimal> FrequenceProc;

	private decimal _count = 0;
			
	private decimal _lastCount = 0;
	public decimal LastCount { get { return _lastCount; } }

	public bool Enabled { get { return _timer.Enabled; } set { ResetCount(); _timer.Enabled = value; } }

	public double Interval { get { return _timer.Interval; } set { _timer.Interval = value; } }

	public ActionMeter(TimeSpan frequency)
	{
		Init(frequency.TotalMilliseconds);
	}

	/// <summary></summary>
	/// <param name="frequency">Frequency in millisecond</param>
	public ActionMeter(double frequency)
	{
		Init(frequency);
	}

	private void Init(double interval)
	{
		_timer = new System.Timers.Timer(interval);
		_timer.AutoReset = true;
		_timer.Enabled = false;
		_timer.Elapsed += delegate {
			_lastCount = _count;
			_count = 0;

			if (FrequenceProc != null)
			FrequenceProc(_lastCount);
		};
	}

	private void ResetCount() { _count = 0; }
	public void Start() { ResetCount(); _timer.Start(); }
	public void Stop() { ResetCount(); _timer.Stop(); }
	public void ReportAction(decimal add = 1) { _count += add; }
}

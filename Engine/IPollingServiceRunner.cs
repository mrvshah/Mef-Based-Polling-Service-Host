namespace Engine
{
	/// <summary>
	/// Provides contract for a polling service
	/// </summary>
	public interface IPollingServiceRunner
	{
		/// <summary>
		/// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
		/// </summary>
		void OnStart();

		/// <summary>
		/// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
		/// </summary>
		void OnStop();

		/// <summary>
		/// When implemented in a derived class, executes when a Pause command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service pauses.
		/// </summary>
		void OnPause();

		/// <summary>
		/// When implemented in a derived class, OnContinue runs when a Continue command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service resumes normal functioning after being paused.
		/// </summary>
		void OnContinue();
	}
}
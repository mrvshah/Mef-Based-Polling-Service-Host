namespace Core
{
	/// <summary>
	/// Defines a command
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Defines the method to be called when the command is invoked
		/// </summary>
		void Execute();
	}
}
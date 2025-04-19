// Ignore Spelling: Plugin

namespace Core;

public class CustomJob : IJobStep
{
	public string Name { get; set; }
	public string Command { get; set; }

	public bool Execute()
	{
		Console.WriteLine($"Executing custom job step: {Name} with command: {Command}");
		return true;
	}
}

// Ignore Spelling: Plugin

namespace Core;

public abstract class StepsPlugin
{
	public string Name;
	public List<IJobStep> Steps;

	public virtual void ListSteps()
	{
		foreach(var step in Steps)
		{
			Console.WriteLine($"Step Name: {step.Name}");
			Console.WriteLine($"Command: {step.Command}");
			Console.WriteLine("---------------------");
		}
	}
}

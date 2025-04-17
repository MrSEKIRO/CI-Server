using Core;

namespace DotnetPlugin
{
	public class DotnetTestStepPlugin : StepsPlugin
	{
		public string Name { get; set; } = "Dotnet Test Plugin";

		public List<IJobStep> Steps { get; set; } = new List<IJobStep>
		{
			new RunTest()
		};

	}

	public class RunTest : IJobStep
	{
		public string Name { get; set; } = "Run Test";
		public string Command { get; set; } = "dotnet test";

		public bool Execute()
		{
			Console.WriteLine($"Executing step: {Name}");
			Console.WriteLine($"Command: {Command}");
			// Simulate command execution
			System.Threading.Thread.Sleep(1000);
			Console.WriteLine("Step executed successfully.");
			return true;
		}
	}
}

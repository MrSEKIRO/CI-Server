using Core;

namespace DotnetPlugin
{
	public class DotnetTestStepPlugin : StepsPlugin
	{
		public DotnetTestStepPlugin()
		{
			this.Name = "Dotnet Test Plugin";
			this.Steps = new List<IJobStep>
			{
				new RunTest(),
				// Add more steps as needed
			};
		}
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

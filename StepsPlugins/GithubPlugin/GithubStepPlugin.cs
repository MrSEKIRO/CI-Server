using Core;

namespace GithubPlugin
{
	public class GithubStepPlugin : StepsPlugin
	{
		public GithubStepPlugin()
		{
			this.Name = "Github Plugin";
			this.Steps = new List<IJobStep>
			{
				new GithubStep1(),
			};
		}
	}

	public class GithubStep1 : IJobStep
	{
		public string Name { get; set; } = "Github Step 1";
		public string Command { get; set; } = "git clone <repository-url>";

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

using Core;

namespace GitlabPlugin
{
	public class GitLabStepPlugin : StepsPlugin
	{
		public GitLabStepPlugin()
		{
			this.Name = "GitLab Plugin";
			this.Steps = new List<IJobStep>
			{
				new GitlabJobStep1(),
				// Add more steps as needed
			};
		}
	}

	public class GitlabJobStep1 : IJobStep
	{
		public string Name { get; set; } = "GitLab Step 1";
		public string Command { get; set; } = "gitlab-runner exec shell <job-name>";

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

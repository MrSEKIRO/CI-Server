using Core;

namespace GitlabPlugin
{
	public class GitLabStepPlugin : StepsPlugin
	{
		public string Name { get; set; } = "GitLab Plugin";

		public List<IJobStep> Steps { get; set; } = new List<IJobStep>
		{
			new GitlabJobStep1 { Name = "GitLab Step 1", Command = "gitlab-runner exec shell <job-name>" },
			// Add more steps as needed
		};
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

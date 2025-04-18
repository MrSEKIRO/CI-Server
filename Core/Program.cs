using Core;
using DotnetPlugin;
using GithubPlugin;
using GitlabPlugin;

Console.WriteLine("CI-Server Starting...");

var server = new CIServer();
var marketPlace = new StepPluginRegistry();

while(true)
{
    Console.WriteLine("Enter option:");
	Console.WriteLine("1. Enter MarketPlace");
	Console.WriteLine("2. Add Job");
	Console.WriteLine("3. Add Job Step");
	Console.WriteLine("4. Execute Job");
	Console.WriteLine("5. Add Job Step from Plugins");
	Console.WriteLine("6. List Job Steps from Plugins");
	Console.WriteLine("0. Exit");
	var input = Console.ReadLine();
	var inputNumber = -1;

	int.TryParse(input, out inputNumber);

	switch(inputNumber)
	{
		case 1:
			EnterMarketPlace(); break;
		case 2:
			AddJob(); break;
		case 3:
			AddJobStep(); break;
		case 4:
			ExecuteJob(); break;
		case 5:
			AddJobStepFromPlugins(); break;
		case 6:
			ListJobStepsFromPlugins(); break;


		case 0:
            Console.WriteLine("Good bye 👋");
			break;
		default:
            Console.WriteLine("Invalid input, Please try again 🤕");
			break;
	}

	if(inputNumber == 0)
		break;
}

void ListJobStepsFromPlugins()
{
	Console.WriteLine("Available Job Steps from Plugins:");
	marketPlace.ListAllPluginSteps();
}

void AddJobStepFromPlugins()
{
	Console.WriteLine("Enter job step name:");
	var jobStepName = Console.ReadLine();

	var step = marketPlace.SearchStep(jobStepName);
	if(step == null)
	{
		Console.WriteLine($"Job step {jobStepName} not found.");
		return;
	}

	Console.WriteLine("Enter index to add at (or leave empty to add at end):");
	var indexInput = Console.ReadLine();
	int? index = null;
	if(!string.IsNullOrEmpty(indexInput))
	{
		int.TryParse(indexInput, out var indexValue);
		index = indexValue;
	}

	var result = server.AddJobStep(step, index);

	if(result)
		Console.WriteLine($"Job step {jobStepName} added.");
	else
		Console.WriteLine("First add the job");
}

void ExecuteJob()
{
	server.ExecuteJob();
}

void AddJobStep()
{
	Console.WriteLine("Enter job step name:");
	var jobStepName = Console.ReadLine();
	Console.WriteLine("Enter job step command:");
	var jobStepCommand = Console.ReadLine();

	Console.WriteLine("Enter index to add at (or leave empty to add at end):");
	var indexInput = Console.ReadLine();
	int? index = null;
	if(!string.IsNullOrEmpty(indexInput))
	{
		int.TryParse(indexInput, out var indexValue);
		index = indexValue;
	}

	server.AddJobStep(jobStepName, jobStepCommand, index);
	Console.WriteLine($"Job step {jobStepName} added.");
}

void AddJob()
{
	Console.WriteLine("Enter job name:");
	var jobName = Console.ReadLine();
	Console.WriteLine("Enter machine name:");
	var machineName = Console.ReadLine();

	server.AddJob(jobName, machineName);
}

void EnterMarketPlace()
{
	while(true)
	{
		Console.WriteLine("(MarketPlace)Enter option:");
		Console.WriteLine("1. List Active Plugins");
		Console.WriteLine("2. Add Plugin");
		Console.WriteLine("3. Remove Plugin");
		Console.WriteLine("4. All Available Plugins");
		Console.WriteLine("0. Exit MarketPlace");

		var input = Console.ReadLine();
		var inputNumber = -1;
		int.TryParse(input, out inputNumber);

		switch(inputNumber)
		{
			case 1:
				marketPlace.ListPlugins(); break;
			case 2:
				Console.WriteLine("Enter plugin name:");
				var pluginName = Console.ReadLine();
				StepsPlugin plugin = null;

				switch(pluginName)
				{
					case "GithubStepPlugin":
						plugin = new GithubStepPlugin(); break;
					case "GitLabStepPlugin":
						plugin = new GitLabStepPlugin(); break;
					case "DotnetTestStepPlugin":
						plugin = new DotnetTestStepPlugin(); break;
					default:
						Console.WriteLine("Invalid plugin name");
						break;
				}

				if(plugin != null)
					marketPlace.AddPlugin(plugin);
				break;
			case 3:
				Console.WriteLine("Enter plugin name:");
				var removePluginName = Console.ReadLine();
				StepsPlugin removePlugin = null;

				switch(removePluginName)
				{
					case "GithubStepPlugin":
						removePlugin = new GithubStepPlugin(); break;
					case "GitLabStepPlugin":
						removePlugin = new GitLabStepPlugin(); break;
					case "DotnetTestStepPlugin":
						removePlugin = new DotnetTestStepPlugin(); break;
					default:
						Console.WriteLine("Invalid plugin name");
						break;
				}

				if(removePlugin != null)
					marketPlace.RemovePlugin(removePlugin);
				break;
			case 4:
				Console.WriteLine("Available Plugins:");
				var availablePlugins = marketPlace.AllAvailablePlugins();
				foreach(var pluginname in availablePlugins)
				{
					Console.WriteLine($"- {pluginname}");
				}
				break;

			case 0:
				Console.WriteLine("Exiting MarketPlace");
				return;
			default:
				Console.WriteLine("Invalid input, Please try again 🤕");
				break;
		}
	}
}
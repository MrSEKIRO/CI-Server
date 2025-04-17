// Ignore Spelling: Plugin

namespace Core;

public class CIServer
{
	private List<StepsPlugin> _plugins = new();

	private Job job = null;

	public bool AddPlugin(StepsPlugin plugin)
	{
		// check if already exists
		if(_plugins.Any(p => p.GetType() == plugin.GetType()))
		{
			Console.WriteLine($"Plugin {plugin.GetType().Name} already exists.");
			return false;
		}

		_plugins.Add(plugin);
		Console.WriteLine($"Plugin {plugin.GetType().Name} added.");
		return true;
	}

	public bool RemovePlugin(StepsPlugin plugin)
	{
		if(_plugins.Remove(plugin))
		{
			Console.WriteLine($"Plugin {plugin.GetType().Name} removed.");
			return true;
		}

		Console.WriteLine($"Plugin {plugin.GetType().Name} not found.");
		return false;
	}

	public void ListPlugins()
	{
		Console.WriteLine("===================");
		Console.WriteLine("Plugins:");
		foreach(var plugin in _plugins)
		{
			Console.WriteLine($"- {plugin.GetType().Name}");
			plugin.ListSteps();
		}
		Console.WriteLine("===================");
	}


	public void AddJob(string name, string machine)
	{
		job = new Job();
		job.Name = name;
		job.RunningMachine = machine;
		Console.WriteLine($"Job {name} added.");
	}

	public bool AddJobStep(string name, string command, int? index = null)
	{
		if(job == null)
		{
			Console.WriteLine("No job found.");
			return false;
		}

		return job.AddCustomStep(name, command, index);
	}

	public bool AddJobStep(IJobStep jobStep, int? index = null)
	{
		if(job == null)
		{
			Console.WriteLine("No job found.");
			return false;
		}

		return job.AddStepFromPlugin(jobStep, index);
	}

	public bool RemoveJobStep(int index)
	{
		if(job == null)
		{
			Console.WriteLine("No job found.");
			return false;
		}

		return job.RemoveStep(index);
	}

	public void ListJobSteps()
	{
		if(job == null)
		{
			Console.WriteLine("No job found.");
			return;
		}

		job.ListSteps();
	}

	public bool ExecuteJob()
	{
		if(job == null)
		{
			Console.WriteLine("No job found.");
			return false;
		}

		var result = job.Execute();

		return result;
	}
}

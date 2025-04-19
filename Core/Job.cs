// Ignore Spelling: Plugin

namespace Core;

public class Job
{
	public string Name { get; set; }
	public string RunningMachine { get; set; }
	public List<IJobStep> Steps { get; set; } = new();

	public bool AddCustomStep(string name, string command, int? index = null)
	{
		// if step is null add it to the end
		if(index == null)
		{
			Steps.Add(new CustomJob { Name = name, Command = command });
			Console.WriteLine($"Step {name} added to job {Name}.");
			return true;
		}

		if(index < 0 || index > Steps.Count)
		{
			Console.WriteLine($"Index {index} is out of range for job {Name}.");
			return false;
		}

		var step = new CustomJob { Name = name, Command = command };
		Steps.Insert((int)index, step);
		Console.WriteLine($"Step {name} added to job {Name} at index {index}.");
		return true;
	}

	public bool AddStepFromPlugin(IJobStep jobStep, int? index = null)
	{
		if(jobStep == null)
		{
			Console.WriteLine("Step is null.");
			return false;
		}

		if(index == null)
		{
			Steps.Add(jobStep);
			Console.WriteLine($"Step {jobStep.Name} added to job {Name}.");
			return true;
		}

		if(index < 0 || index > Steps.Count)
		{
			Console.WriteLine($"Index {index} is out of range for job {Name}.");
			return false;
		}

		Steps.Insert((int)index, jobStep);
		Console.WriteLine($"Step {jobStep.Name} added to job {Name} at index {index}.");
		return true;
	}

	public bool RemoveStep(int index)
	{
		if(index < 0 || index >= Steps.Count)
		{
			Console.WriteLine($"Step {index} not found in job {Name}.");
			return false;
		}

		Steps.RemoveAt(index);
		Console.WriteLine($"Step {index} removed from job {Name}.");
		return true;
	}

	public void ListSteps()
	{
		Console.WriteLine($"===================\nSteps for job {Name}:");
		for(int i = 0; i < Steps.Count; i++)
		{
			Console.WriteLine("---------------------");
			Console.WriteLine($"| {i} |");
			Console.WriteLine($"| {Steps[i].Name} |");
			Console.WriteLine($"| {Steps[i].Command} |");
			Console.WriteLine("---------------------");
			if(i < Steps.Count - 1)
			{
				Console.WriteLine("       |");
				Console.WriteLine("       v");
			}
		}
		Console.WriteLine("===================");
	}

	public bool Execute()
	{
		Console.WriteLine($"Executing job {Name} on machine {RunningMachine}...");
		foreach(var step in Steps)
		{
			var success = step.Execute();

			if(!success)
			{
				Console.WriteLine($"Job {Name} failed at step {step.Name}.");
				return false;
			}

			Console.WriteLine($"Step {step.Name} completed successfully.");
		}
		Console.WriteLine($"Job {Name} completed successfully.");
		return true;
	}
}

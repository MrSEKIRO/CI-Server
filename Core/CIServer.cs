﻿// Ignore Spelling: Plugin

namespace Core;

public class CIServer
{
	private Job job = null;

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

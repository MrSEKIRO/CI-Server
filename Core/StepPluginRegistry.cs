namespace Core;

public class StepPluginRegistry
{
	private List<StepsPlugin> _activePlugins = new();

	public StepPluginRegistry()
	{
	}

	public bool AddPlugin(StepsPlugin plugin)
	{
		// check if already exists
		if(_activePlugins.Any(p => p.GetType() == plugin.GetType()))
		{
			Console.WriteLine($"Plugin {plugin.GetType().Name} already exists.");
			return false;
		}

		_activePlugins.Add(plugin);
		Console.WriteLine($"Plugin {plugin.GetType().Name} added.");
		return true;
	}

	public bool RemovePlugin(StepsPlugin plugin)
	{
		if(_activePlugins.Remove(plugin))
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
		foreach(var plugin in _activePlugins)
		{
			Console.WriteLine($"- {plugin.GetType().Name}");
			plugin.ListSteps();
		}
		Console.WriteLine("===================");
	}

	public void ListAllPluginSteps()
	{
		Console.WriteLine("===================");
		Console.WriteLine("All Steps:");
		foreach(var plugin in _activePlugins)
		{
			Console.WriteLine($"Plugin: {plugin.GetType().Name}");
			plugin.ListSteps();
		}
		Console.WriteLine("===================");
	}

	public IJobStep SearchStep(string name)
	{
		var step = _activePlugins
					.SelectMany(p => p.Steps)
					.Where(x => x.Name.Contains(name))
					.FirstOrDefault();

		return step;
	}
}

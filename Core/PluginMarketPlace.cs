using DotnetPlugin;
using GithubPlugin;
using GitlabPlugin;

namespace Core;

public class PluginMarketPlace
{
	private List<StepsPlugin> _plugins = new();

	public PluginMarketPlace()
	{
		_plugins.Add(new GithubStepPlugin());
		_plugins.Add(new DotnetTestStepPlugin());
		_plugins.Add(new GitLabStepPlugin());
	}
}

// Ignore Spelling: Plugin

namespace Core;

public interface IJobStep
{
	public string Name { get; set; }
	public string Command { get; set; }

	public bool Execute();
}

// Ignore Spelling: Plugin

namespace Core;

public interface INotificationPlugin
{
	public string Name { get; set; }

	public void Notify(string message);
}
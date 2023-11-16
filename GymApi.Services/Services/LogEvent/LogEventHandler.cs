using GymApi.UseCases.Notification;
using MediatR;

namespace GymApi.UseCases.Services.LogEvent;

public class LogEventHandler :  INotificationHandler<ErrorNotification>
{
	public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
	{
		return Task.Run(() =>
		{
			Console.WriteLine($"ERRO: '{notification.Class} \n {notification.Exception} \n {notification.StackTracer}'");
		});
	}
}
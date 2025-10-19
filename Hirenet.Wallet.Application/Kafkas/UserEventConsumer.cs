using Confluent.Kafka;
using Hirenet.Wallet.Application.Cqrs.Commands;
using Hirenet.Wallet.Application.DTOs;
using Hirenet.Wallet.Application.Interfaces;
using Hirenet.Wallet.Domain.Models;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.Kafkas;
public class UserEventConsumer : BackgroundService {
	private readonly IConsumer<string, string> consumer;
	private readonly ILogger<UserEventConsumer> logger;
	private readonly IServiceProvider serviceProvider;



	public UserEventConsumer(IConsumer<string, string> consumer, ILogger<UserEventConsumer> logger, IServiceProvider serviceProvider) {
		this.consumer = consumer;
		this.logger = logger;
		this.consumer.Subscribe("user-created-events");
		this.serviceProvider = serviceProvider;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
		logger.LogInformation("Wallet service listening on 'user.create'");
		while (!stoppingToken.IsCancellationRequested) {
			try {
				using var scope = serviceProvider.CreateScope();	
				var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

				var result = consumer.Consume(stoppingToken);
				if (result?.Message == null) continue;
				var evt = JsonSerializer.Deserialize<UserCreatedEvent>(result.Message.Value);
				logger.LogInformation("User Id Consume {userId},", evt?.UserId);


				var userModel = new CreateWalletDTO();
				userModel.UserId = evt.UserId;
				var command = new CreateWalletCommand(userModel);
				await mediator.Send(command, stoppingToken);
			} catch (ConsumeException ex) {
				logger.LogInformation(ex, "Error Consuming");
			}
		}
	}
}
public record UserCreatedEvent(string UserId);

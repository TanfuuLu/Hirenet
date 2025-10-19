using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hirenet.Authenticate.Application.Kafkas;
public class UserEventProducer {
	private readonly IProducer<string,string> producer;

    public UserEventProducer(IProducer<string, string> producer) {
	  this.producer = producer;
    }
	public async Task PublishUserCreatedAsync(string userId) {
		var evt = new {
			UserId = userId,
			CreatedAt = DateTime.UtcNow
		};
		var jsonEvt = JsonSerializer.Serialize(evt);
		await producer.ProduceAsync("user-created-events", new Message<string, string> {
			Key = userId,
			Value = jsonEvt
		});
		Console.WriteLine($"✅ [UserService] Published UserCreated for {userId}");
	}
}

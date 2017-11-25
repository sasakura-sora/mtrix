using Matrix.DataStore;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Linq;

namespace Matrix.Framework.IntegrationTest
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RoomServiceTests
    {
        RoomService service;
        EventService events;

        [SetUp]
        public void Setup()
        {
            var roomRepo = new RoomMemoryRepository();
            events = new EventService();

            service = new RoomService(roomRepo, events);
        }

        [Test]
        public async Task RoomIsCreated_RoomExistsInList()
        {
            var request = new Model.Rooms.RoomCreate
            {
                name = "testName",
                topic = "topic"
            };

            var newRoom = await service.Create(request);

            Assert.IsNotNull(newRoom.room_id);

            var room = await service.IdFind(newRoom.room_id);

            Assert.IsNotNull(room);
            Assert.AreEqual("testName", room.name);
            Assert.AreEqual("topic", room.topic);
        }

        [Test]
        public async Task RoomIsCreatedAndJoined_UserExistInList()
        {
            var request = new Model.Rooms.RoomCreate
            {
                name = "testName",
                topic = "topic",
                visibility = Model.Visibility.Public
            };

            var user = new Model.Profiles.Profile
            {
                userId = "1"
            };

            var newRoom = await service.Create(request);

            Assert.IsNotNull(newRoom.room_id);

            var room = await service.IdFind(newRoom.room_id);

            await service.Join(user.userId, newRoom.room_id);

            var members = await events.Members(newRoom.room_id);

            Assert.IsTrue(members.Any(x => x.sender == user.userId));
        }
    }
}


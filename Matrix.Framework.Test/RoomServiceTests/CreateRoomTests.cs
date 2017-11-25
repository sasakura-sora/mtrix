using Matrix.DataStore.Interfaces;
using Matrix.Model.Rooms;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Matrix.Framework.Test.RoomServiceTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CreateRoomTests
    {
        private IRoomRepository roomRepo;
        private RoomService service;

        [SetUp]
        public void Setup()
        {
            roomRepo = Substitute.For<IRoomRepository>();

            service = new RoomService(roomRepo);
        }

        [Test]
        public async Task CreatingARoom_IsStored()
        {
            var request = new RoomCreate();

            var response = await service.Create(request);

            Assert.IsNotNull(response);
            Assert.AreNotEqual(Guid.Empty, response.room_id);

            await roomRepo.Received(1).RoomCreate(Arg.Any<PublicRoomsChunk>());
        }
    }
}

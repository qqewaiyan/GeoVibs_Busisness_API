namespace GeoVibs_Busisness_API.Service.Room
{
    using Microsoft.AspNetCore.SignalR;

    public class RoomHub : Hub
    {
        // Send updated room status to all clients
        //public async Task SendRoomUpdate(RoomStatusDto room)
        //{
        //    await Clients.All.SendAsync("ReceiveRoomUpdate", room);
        //}
    }
}

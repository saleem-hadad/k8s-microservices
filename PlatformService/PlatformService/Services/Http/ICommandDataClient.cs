using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.Services.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto platformReadDto);
    }
}
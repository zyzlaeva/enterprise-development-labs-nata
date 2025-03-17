using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Album;

namespace Mediateca.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций над авто
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class AlbumController(ICrudService<AlbumDto, AlbumCreateUpdateDto, int> crudService)
    : CrudControllerBase<AlbumDto, AlbumCreateUpdateDto, int>(crudService);

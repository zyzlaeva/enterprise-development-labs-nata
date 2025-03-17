using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Track;

namespace Mediateca.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций над маршрутами
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class TrackController(ICrudService<TrackDto, TrackCreateUpdateDto, int> crudService)
    : CrudControllerBase<TrackDto, TrackCreateUpdateDto, int>(crudService);

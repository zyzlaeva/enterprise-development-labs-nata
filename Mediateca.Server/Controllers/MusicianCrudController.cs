using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Musician;

namespace Mediateca.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class MusicianController(ICrudService<MusicianDto, MusicianCreateUpdateDto, int> crudService)
    : CrudControllerBase<MusicianDto, MusicianCreateUpdateDto, int>(crudService);

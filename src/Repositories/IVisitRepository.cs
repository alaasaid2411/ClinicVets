using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Defines visit storage operations used by services.
/// </summary>
public interface IVisitRepository
{
    Visit Add(Visit visit);
}

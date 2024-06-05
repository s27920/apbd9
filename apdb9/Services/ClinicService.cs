using apdb9.Repositories;

namespace apdb9.Services;

public interface IClinicService{

}

public class ClinicService
{
    private readonly ClinicRepository _repository;

    public ClinicService(ClinicRepository repository)
    {
        _repository = repository;
    }
}
using DogApi.Model.Dto;
using DogApi.Model.Entities;

namespace DogApi.Services
{
    public interface IDogServices
    {
        Task<(bool IsSuccess, string ErrorMessage)> CreateDogAsync(CreateDogRequest entity);
        Task<(bool IsSuccess, string ErrorMessage, List<Dog> Dogs)> GetQueriedDogsAsync(GetQueriedDogsRequest queriedDogs);
    }
}

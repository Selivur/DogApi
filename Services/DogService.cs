using DogApi.Model.DbContext;
using DogApi.Model.Dto;
using DogApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DogApi.Services
{
    public class DogService :IDogServices
    {
        private readonly DogContext _context;
        public DogService(DogContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> CreateDogAsync(CreateDogRequest dogRequest)
        {
            try
            {
                if (_context.Dogs.Any(d => d.Name == dogRequest.Name))
                {
                    return (false, "A dog with the same name already exists");
                }

                Dog dogs = new Dog
                {
                    Color = dogRequest.Color,
                    Name = dogRequest.Name,
                    TailLength = dogRequest.TailLength,
                    Weight = dogRequest.Weight
                };
                _context.Dogs.Add(dogs);
                var addedEntitiesCount = await _context.SaveChangesAsync();
                return addedEntitiesCount == 0 ? (false, "Something went wrong when adding to DB") : (true, string.Empty);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<(bool IsSuccess, string ErrorMessage, List<Dog> Dogs)> GetQueriedDogsAsync(GetQueriedDogsRequest queriedDogs)
        {
            ArgumentNullException.ThrowIfNull(queriedDogs, nameof(queriedDogs));
            try
            {
                var dogsQuery = _context.Dogs.AsNoTracking();
                if (!queriedDogs.Atribute.IsNullOrEmpty())
                {
                    switch (queriedDogs.Atribute.ToLower())
                    {
                        case "name":
                            dogsQuery = queriedDogs.Order.ToLower() == "desc" ?
                                (IQueryable<Dog>)_context.Dogs.OrderByDescending(d => d.Name) :
                                (IQueryable<Dog>)_context.Dogs.OrderBy(d => d.Name);
                            break;
                        case "color":
                            dogsQuery = queriedDogs.Order.ToLower() == "desc" ?
                                (IQueryable<Dog>)_context.Dogs.OrderByDescending(d => d.Color) :
                                (IQueryable<Dog>)_context.Dogs.OrderBy(d => d.Color);
                            break;
                        case "taillength":
                            dogsQuery = queriedDogs.Order.ToLower() == "desc" ?
                                (IQueryable<Dog>)_context.Dogs.OrderByDescending(d => d.TailLength) :
                                (IQueryable<Dog>)_context.Dogs.OrderBy(d => d.TailLength);
                            break;
                        case "weight":
                            dogsQuery = queriedDogs.Order.ToLower() == "desc" ?
                                (IQueryable<Dog>)_context.Dogs.OrderByDescending(d => d.Weight) :
                                (IQueryable<Dog>)_context.Dogs.OrderBy(d => d.Weight);
                            break;
                        default:
                            return (false, "Incorrect atribute", null);
                    }
                }

                // Pagination
                if (queriedDogs.PageNumber <= 0 || queriedDogs.PageSize <= 0)
                {
                    return (false, "PageNumber and PageSize could not be 0 or negative.", null);

                }
                int startIndex = (int)((queriedDogs.PageNumber - 1) * queriedDogs.PageSize);
                var dogs = await dogsQuery.Skip(startIndex).Take((int)queriedDogs.PageSize).ToListAsync();
                return (true, string.Empty, dogs);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }
        }
    }
}


### DogApi

#### Description
This is a simple API built with ASP.NET Core Web API and Entity Framework Core for managing information about dogs. It provides endpoints for creating dogs and retrieving dogs with pagination and sorting capabilities.

#### Features
- **Create Dog**: POST endpoint to add a new dog to the database.
- **Get Queried Dogs**: GET endpoint to retrieve a list of dogs based on specified parameters such as sorting attribute, sort order, page number, and page size.

#### Technologies Used
- ASP.NET Core Web API
- Entity Framework Core

#### Endpoints

##### Create Dog
- **URL**: `/dog`
- **Method**: `POST`
- **Request Body**:
  ```json
  {
    "name": "string",
    "color": "string",
    "tailLength": "float",
    "weight": "float"
  }
  ```
- **Response**:
  - `201 Created` if the dog is successfully created.
  - `400 Bad Request` if there are validation errors or if a dog with the same name already exists.

##### Get Queried Dogs
- **URL**: `/dogs`
- **Method**: `GET`
- **Query Parameters**:
  - `attribute` (string): Attribute by which to sort the list (e.g., "name", "color", "tailLength", "weight").
  - `order` (string): Sort order ("asc" for ascending or "desc" for descending).
  - `pageNumber` (integer): Page number for pagination (starting from 1).
  - `pageSize` (integer): Number of items per page.
- **Response**:
  - `200 OK` with the list of queried dogs.
  - `400 Bad Request` if there are validation errors or if the parameters are incorrect.

#### Error Handling
- Validation errors are returned with appropriate error messages.
- Error messages are provided for failed operations.

#### How to Use
1. Clone the repository.
2. Set up the database connection in `appsettings.json`.
3. Run the application.
4. Use the provided endpoints to interact with the API.

#### License
This project is licensed under the [MIT License](LICENSE).

---

Feel free to contribute and improve this project! If you encounter any issues or have suggestions, please create an issue or submit a pull request.

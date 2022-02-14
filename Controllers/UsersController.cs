using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using JsonShowcase.Models;
using JsonShowcase.Services;

namespace JsonShowcase.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {

        // When the GET request is called in our JavaScript code, this part of the controller says what to do
        // Essentially, whenever we make a GET request, the GetData() method from DataServices.cs will be called.
        // This method returns the content of Users.json in List format.
        // The controller then converts the List to an Array and returns it (sends it back to the frontend)
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return DataService.GetData().ToArray();
        }

        // When the POST request is called in our JavaScipt code, the following Post method is executed.
        // This method calls the PushData() method within DataService.cs to write the new JSON object to the JSON file
        // The object that we are sending in the JavaScript is found in the parameters of this method.
        // Our method parameter states that we want a User object.
        [HttpPost]
        public void Post([FromBody] User user)
        {
            DataService.PushData(user);
        }

    }
}

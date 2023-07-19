using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_WEB_API.DTOs;
using ToDo_WEB_API.Models;
using ToDo_WEB_API.Services;

namespace ToDo_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDto>>> Get()
        {
            return (await _todoService.GetToDoItemsAsync()).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDto>> Get(int id)
        {
            var item = await _todoService.GetToDoItemAsync(id);
            return 
                item != null 
                ? item 
                : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> Post(
            [FromBody] CreateToDoItemRequest request
            )
        {
            var createdItem = await _todoService.CreateTodoItem(request);
            return createdItem;
        }
    }
}

/* MVC
    Create:
        GET     /products/create  -> html 
        POST    /products/create  -> html
    Update:
        GET     /products/update/{id}  -> html 
        POST    /products/upate/{id}  -> html  
    Delete:
        GET     /products/delete/{id}  -> html 
        POST    /products/delete/{id}  -> html
    GetAll:
        GET     /products/index  -> html
    Get one
        GET     /products/index{id}  -> html


Web Api
    Create:
        POST     /products  -> json
    Update:
        PUT      /products/{id}  -> json 
    Delete:
        DELETE   /products/{id}  -> json
    GetAll:
        GET      /products  -> json
    Get one
        GET      /products/{id}  -> json    
*/
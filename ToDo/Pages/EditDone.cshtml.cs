using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDo.Pages
{
    public class EditDoneModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IToDoList _toDoService;

        public EditDoneModel(IConfiguration configuration, IToDoList toDoService)
        {
            _configuration = configuration;
            _toDoService = toDoService;
        }

        #region Property
        [BindProperty]
        public string ToDoName { get; set; }
        [BindProperty]
        public string Decription { get; set; }
        [BindProperty]
        public bool Done { get; set; }
        public ToDos ToDo { get; set; }

        #endregion

        public void OnGet(int Id)
        {
            ToDo = _toDoService.GetToDo(Id);
        }

        public void OnPost(int Id)
        {
            ToDo = _toDoService.UpdateToDos(ToDoName, Decription, Id, Done);
        }


        public void OnPostRemove(int Id)
        {
            _toDoService.RemoveToDos(Id);

        }



    }
}


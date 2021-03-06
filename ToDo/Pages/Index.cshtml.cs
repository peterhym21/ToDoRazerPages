﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ToDoService.Interfaces;
using ToDoService.Models;
using ToDoService.Services;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IToDoList _ToDoService;
        private readonly ICustomerService _customerService;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IToDoList ToDoService, ICustomerService customerService)
        {
            _logger = logger;
            _configuration = configuration;
            _ToDoService = ToDoService;
            _customerService = customerService;
        }

        #region propertys
        public List<ToDos> ToDosList { get; set; }
        public string NewItem { get; set; }



        [BindProperty, Required]
        public string ToDoName { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty, Required]
        public string Name { get; set; }

        [BindProperty, Required]
        public string Email { get; set; }

        [BindProperty]
        public DateTime PickDateForward { get; set; }
        [BindProperty]
        public DateTime PickDateOlder { get; set; }

        #endregion

        // vis liste af todo
        public void OnGet()
        {
            ToDosList = _ToDoService.GetToDos();
        }

        // tilføj todo
        public void OnPost()
        {
            ToDosList = _ToDoService.AddToDos(ToDoName, Description);
            ToDoName = "";
            Description = "";
            ModelState.Clear();
        }

        // tilføj til newsletter
        public void OnPostNewsLetter()
        {
            _customerService.AddCustomerNewsletter(Name, Email);
            _customerService.SendEmailNews(Name, Email);
            ToDoName = "";
            Description = "";
            ModelState.Clear();
        }

        // tjek dato og send den vidre
        public IActionResult OnPostFilters()
        {
            if (PickDateForward != DateTime.MinValue)
            {
                ToDosList = _ToDoService.FilterForvard(PickDateForward);
            }
            if (PickDateOlder != DateTime.MinValue)
            {
                ToDosList = _ToDoService.FilterOlder(PickDateOlder);
            }
            return Page();

        }

        public void OnPostAFK()
        {
            Process.Start("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Binding of Isaac Rebirth\\isaac-ng.exe");
        }

    }
}

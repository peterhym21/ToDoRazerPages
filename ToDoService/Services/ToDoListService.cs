﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoService.Interfaces;
using ToDoService.Models;

namespace ToDoService.Services
{
    public class ToDoListService : IToDoList
    {
        #region list and propetys
        private static List<ToDos> ToDosL = new List<ToDos>();
        private ToDos Todos = new ToDos();
        private static List<ToDos> DoneToDosL = new List<ToDos>();
        int i = 1;
        #endregion

        #region methoead that manipulate data
        public List<ToDos> AddToDos(string toDo, string description)
        {
            ToDosL.Add(new ToDos { ToDoName = toDo, Done = false, Description = description, Id = i });
            ++i;
            return ToDosL;
        }

        public ToDos moveToDos(string toDo, string Description, int id)
        {
            foreach (ToDos toDos in ToDosL)
            {
                if (id == toDos.Id)
                {
                    toDos.Done = true;
                    DoneToDosL.Add(toDos);
                    Todos = toDos;
                }
            }
            if (Todos.Id == id)
            {
                ToDosL.RemoveAt(--id);
            }

            return Todos;
        }

        public ToDos EdditToDos(string toDo, string Description, int id)
        {
            foreach (ToDos toDos in ToDosL)
            {
                if (id == toDos.Id)
                {
                    if (toDo != null)
                        toDos.ToDoName = toDo;
                    if (Description != null)
                        toDos.Description = Description;
                    toDos.Done = false;
                    Todos = toDos;
                }
            }
            return Todos;
        }

        public void RemoveToDos(int id)
        {
            DoneToDosL.RemoveAt(--id);

        }

        #endregion

        #region Get metoder
        public List<ToDos> GetDoneToDos()
        {
            return DoneToDosL;
        }

        public List<ToDos> GetToDos()
        {
            return ToDosL;
        }

        public ToDos GetToDoForEdit(int id)
        {
            foreach (ToDos todo in ToDosL)
            {
                if (id == todo.Id)
                {
                    Todos = todo;
                }
            }
            return Todos;
        }

        public ToDos GetDoneToDoForEdit(int id)
        {
            foreach (ToDos todo in DoneToDosL)
            {
                if (id == todo.Id)
                {
                    Todos = todo;
                }
            }
            return Todos;
        }


        #endregion

    }
}
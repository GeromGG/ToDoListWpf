namespace ToDoListWpf
{
    using System.Collections.Generic;

    public class Project
    {
        public Project()
        {

        }

        public Project(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Имя проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список задач
        /// </summary>
        public List<ProjectTask> Tasks = new();

        /// <summary>
        /// Добавление задачи в список
        /// </summary>
        /// <param name="indexNumber">Порядковый номер, важность</param>
        /// <param name="description">Описание задачи</param>
        /// <param name="performed">Флаг выполнения</param>
        public void AddTask(string description)
        {
            var projectTask = new ProjectTask(description);
            Tasks.Add(projectTask);
        }

        /// <summary>
        /// Удаление задачи из списка
        /// </summary>
        /// <param name="projectTask">Задача которую нужно удалить</param>
        /// <returns></returns>
        public bool DeleteTask(ProjectTask projectTask)
        {            
            return Tasks.Remove(projectTask);
        }




    }
}

namespace ToDoListWpf
{

    public class ProjectTask
    {
        public ProjectTask()
        {

        }

        public ProjectTask(int indexNumber, string description, bool performed = false)
        {
            IndexNumber = indexNumber;
            Description = description;
            Performed = performed;
        }

        /// <summary>
        /// порядковый номер, важность
        /// </summary>
        public int IndexNumber { get; set; }

        /// <summary>
        /// описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// флаг выполнения
        /// </summary>
        public bool Performed { get; set; }


    }
}
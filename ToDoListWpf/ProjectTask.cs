namespace ToDoListWpf
{

    public class ProjectTask
    {
        public ProjectTask()
        {

        }

        public ProjectTask( string description, bool performed = false)
        {
            ++Index;
            IndexNumber = Index;
            Description = description;
            Performed = performed;
        }

        /// <summary>
        /// порядковый номер, важность
        /// </summary>
        public int IndexNumber { get; set; } = 1;

        /// <summary>
        /// описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// флаг выполнения
        /// </summary>
        public bool Performed { get; set; }

        private static int Index { get; set; }
    }
}
using School.FrameworkBL.Models.Base;

namespace School.FrameworkBL.Models.ListModels
{
    public class StudentListModel : ModelBase
    {
        private string name;

        public string Name
        {
            get => name;
            set => Set(() => Name, ref name, value);
        }
    }
}
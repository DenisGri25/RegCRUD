using System;

namespace RegCRUD.Models
{
    public class Employees
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string SecondName { set; get; }
        public string MiddleName { set; get; }
        public DateTime HiringDate { set; get; }
        public PositionName Position { set; get; }
        public string Company { set; get; }
    }
}
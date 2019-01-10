using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSamples.Models {
    public class ToDoItemViewModel {
        public int Id { get; }
        public bool IsComplete => Tasks.Count == 0;
        public List<string> Tasks { get; }

        public ToDoItemViewModel(int id, params string[] tasks) {
            Id = id;
            Tasks = new List<string>(tasks);
        }
    }
}
